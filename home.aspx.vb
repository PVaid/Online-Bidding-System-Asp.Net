Imports System.Data.SqlClient

Public Class home
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim conn_string As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
            Dim user_email = Request.Cookies("user").Item("email")
            Dim conn As New SqlConnection(conn_string)
            conn.Open()
            Dim cmd = New SqlCommand("Select first_name from users where email = '" & user_email & "'", conn)
            Dim f_name = cmd.ExecuteScalar().ToString()
            greeting_name.Text = f_name
            ' ----
            Dim htmldiv As New StringBuilder()
            Dim str_sql = "Select * from items order by item_id desc"
            'Dim str_sql2 As String
            cmd = New SqlCommand(str_sql, conn)
            Dim rowReader As SqlDataReader = cmd.ExecuteReader()
            'Dim maxBid
            If rowReader.HasRows Then
                While rowReader.Read()
                    'str_sql2 = "select max(bid_price) from bids where item_id='" & rowReader("item_id") & "'"
                    'cmd = New SqlCommand(str_sql2, conn)
                    'maxBid = cmd.ExecuteScalar().ToString()
                    htmldiv.Append("<div class='col s12 m4'>")
                    htmldiv.Append("<div class='card'>")
                    htmldiv.Append("<div class='card-image'>")
                    htmldiv.Append("<img height='200px' width='240px' src='uploads/" & rowReader("image") & "'>")
                    Dim today_date = Date.Today()
                    Dim compare_date = DateTime.Compare(rowReader("duration"), today_date)
                    If compare_date > 0 Then
                        htmldiv.Append("<div class='card-title bold-t'>Open</div>")
                    Else
                        htmldiv.Append("<div class='card-title cut-through bold-t'>Closed</div>")
                    End If
                    'htmldiv.Append("<span class='card-title'> $" & maxBid & "</span>")
                    htmldiv.Append("<a href='item.aspx?id=" & rowReader("item_id") & "' class='btn-floating halfway-fab waves-effect waves-light purple darken-2'><i class='material-icons'>add_shopping_cart</i></a>")
                    htmldiv.Append("</div>")
                    htmldiv.Append("<div class='card-content'>")
                    htmldiv.Append(" <span class='card-title'>" & rowReader("item_name") & "</span>")
                    htmldiv.Append("<p style='font-size:12px'>Closing Date:" & rowReader("duration") & "</p>")
                    htmldiv.Append("</div>")
                    htmldiv.Append("</div>")
                    htmldiv.Append("</div>")
                End While
                PlaceHolder1.Controls.Add(New LiteralControl(htmldiv.ToString()))


            End If
        Catch ex As Exception

        End Try
    End Sub

End Class