Imports System.Data.SqlClient
Imports System.Globalization

Public Class afterLogin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userCookie As HttpCookie = Request.Cookies("user")
        If userCookie Is Nothing Then
            Response.Redirect("index.aspx")
        End If
    End Sub

    Private Sub logout_Click(sender As Object, e As EventArgs) Handles logout.Click
        Dim userCookie As HttpCookie
        userCookie = New HttpCookie("user")
        userCookie.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(userCookie)
        Response.Redirect("index.aspx")
    End Sub

    Private Sub logoutm_Click(sender As Object, e As EventArgs) Handles logoutm.Click
        Dim userCookie As HttpCookie
        userCookie = New HttpCookie("user")
        userCookie.Expires = DateTime.Now.AddDays(-1)
        Response.Cookies.Add(userCookie)
        Response.Redirect("index.aspx")
    End Sub

    Protected Sub check_date_validate(source As Object, args As ServerValidateEventArgs) Handles check_date.ServerValidate
        Dim today_date = DateTime.Today()
        Dim date_culture = New CultureInfo("en-US")
        Dim compare_date = DateTime.Compare(Date.Parse(args.Value.ToString()), today_date)
        If compare_date > 0 Then
            args.IsValid = True
        Else
            args.IsValid = False
        End If
    End Sub

    Private Sub start_bid_Click(sender As Object, e As EventArgs) Handles start_bid.Click
        Try
            Dim user_email = Request.Cookies("user").Item("email")
            Dim date_culture = New CultureInfo("en-US")
            Dim bid_duration = Date.Parse(run_date.Text)
            Dim conn_string As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
            Dim conn As New SqlConnection(conn_string)
            conn.Open()
            Dim str_sql = "Select max(item_id) from items"
            Dim cmd = New SqlCommand(str_sql, conn)
            Dim item_id = Convert.ToInt32(cmd.ExecuteScalar()) + 1
            str_sql = "Select uid from users where email = '" & user_email & "'"
            cmd = New SqlCommand(str_sql, conn)
            Dim uid = Convert.ToInt32(cmd.ExecuteScalar())
            Dim save_path = Server.MapPath("uploads/") & image_upload.FileName
            image_upload.SaveAs(save_path)
            str_sql = "Insert into items (item_id, item_name, base_price, description, location, duration, uid, image) values ('" & item_id & "','" & title.Text & "','" & base_price.Text & "','" & description.Text & "','" & location.Text & "','" & bid_duration & "', '" & uid & "', '" & image_upload.FileName & "')"
            cmd = New SqlCommand(str_sql, conn)
            cmd.ExecuteNonQuery()
            Response.Redirect("home.aspx")
        Catch ex As Exception
            error_msg.Text = ex.ToString()
        End Try
    End Sub
End Class