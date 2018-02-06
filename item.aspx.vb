Imports System.Data.SqlClient

Public Class item
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim item_id = Request.QueryString.Item("id")
        Dim conn_string As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
        Dim user_email = Request.Cookies("user").Item("email")
        Dim conn As New SqlConnection(conn_string)
        conn.Open()
        Dim cmd = New SqlCommand("Select * from items where item_id = '" & item_id & "'", conn)
        makebid_div.Visible = False
        closedbid_div.Visible = False
        Dim item_data = cmd.ExecuteReader()
        Dim item_exists = False
        'Dim maxBid
        If item_data.HasRows Then
            While item_data.Read()
                Image1.ImageUrl = "uploads/" & item_data("image")
                title.Text = item_data("item_name")
                desc.Text = item_data("description")
                base_price.Text = "$" & item_data("base_price")
                location.Text = "<span class='material-icons'>gps_fixed</span> " & item_data("location")
                hidden_max.Text = item_data("base_price")
                Dim today_date = Date.Today()
                Dim compare_date = DateTime.Compare(item_data("duration"), today_date)
                If compare_date > 0 Then
                    makebid_div.Visible = True
                Else
                    closedbid_div.Visible = True
                End If
                item_exists = True
            End While
        Else
            debug.Text = "Item not found"
        End If
        item_data.Close()
        cmd = New SqlCommand("Select * from bids inner join users on bids.uid = users.uid where item_id='" & item_id & "' order by bid_price desc", conn)
        Dim bidsReader = cmd.ExecuteReader()
        Dim bidDiv = New StringBuilder()
        If bidsReader.HasRows Then
            bidDiv.Append("<ul class='collection'>")
            bidDiv.Append("<h6 class='center-block's>Bid on this items</h6><hr />")
            While bidsReader.Read()
                bidDiv.Append("<li class='collection-item dismissable center-align' style='max-width:110px; margin:auto'><div>" & bidsReader.Item("first_name") & "</div><div><b>$" & bidsReader.Item("bid_price") & "</b></div></li>")
            End While
            bidDiv.Append("</ul>")
        ElseIf item_exists Then
            bidDiv.Append("<div class='center-block'>No bids made by any user yet!</div>")
        End If

        bidsPlaceholder.Controls.Add(New LiteralControl(bidDiv.ToString()))


    End Sub

    Protected Sub make_bid_Click(sender As Object, e As EventArgs) Handles make_bid.Click
        If Page.IsValid Then
            Dim item_id = Request.QueryString.Item("id")
            Dim user_email = Request.Cookies("user").Item("email")
            Dim conn_string As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
            Dim conn As New SqlConnection(conn_string)
            conn.Open()
            Dim str_sql = "Select uid from users where email = '" & user_email & "'"
            Dim cmd = New SqlCommand(str_sql, conn)
            Dim uid = Convert.ToInt32(cmd.ExecuteScalar())

            str_sql = "Select max(bid_id) from bids"
            cmd = New SqlCommand(str_sql, conn)
            Dim bid_id = Convert.ToInt32(cmd.ExecuteScalar()) + 1
            Dim tdate = DateTime.Today
            str_sql = "Insert into bids (bid_id, uid, item_id, bid_price, time) values ('" & bid_id & "','" & uid & "','" & item_id & "','" & bid_price.Text & "','" & tdate & "')"
            cmd = New SqlCommand(str_sql, conn)
            cmd.ExecuteNonQuery()
            Response.Redirect(Request.Url.ToString)
            MsgBox(item_id & uid)
        End If
        
    End Sub
End Class