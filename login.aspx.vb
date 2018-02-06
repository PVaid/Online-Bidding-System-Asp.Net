Imports System.Data.SqlClient

Public Class login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        Dim str_sql As String = "SELECT * from users where email= '" & u_email.Text & "'and password='" & u_password.Text & "'"
        Dim conn_string As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
        Dim conn As New SqlConnection(conn_string)
        conn.Open()
        Dim cmd = New SqlCommand(str_sql, conn)
        Dim dr As SqlDataReader
        dr = cmd.ExecuteReader()
        If dr.HasRows Then
            Dim aCookie As New HttpCookie("user")
            aCookie.Values("email") = u_email.Text
            aCookie.Expires = DateTime.Now.AddDays(30)
            Response.Cookies.Add(aCookie)
            Response.Redirect("home.aspx")
        Else
            error_msg.Text = "Incorrect Email or Password"
            dr.Close()
        End If
    End Sub
End Class