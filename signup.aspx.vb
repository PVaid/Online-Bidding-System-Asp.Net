Imports System.Data.SqlClient

Public Class signup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub signup_Click(sender As Object, e As EventArgs) Handles signup.Click
        Try
            If Page.IsValid Then
                Dim conn_string As String = ConfigurationManager.ConnectionStrings("ApplicationServices").ConnectionString
                Dim str_sql As String = "SELECT * from users where email= '" & u_email.Text & "'"
                Dim conn As New SqlConnection(conn_string)
                conn.Open()
                Dim cmd = New SqlCommand(str_sql, conn)
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    error_msg.Text = "User already exists"
                    dr.Close()
                Else
                    dr.Close()
                    Dim uid As Integer
                    Dim register_date = DateTime.Now.ToString()
                    str_sql = "Select count(*) from users"
                    cmd = New SqlCommand(str_sql, conn)
                    uid = Convert.ToInt32(cmd.ExecuteScalar()) + 1
                    str_sql = "Insert into users (uid, first_name, last_name, email, password, register_date) values ('" & uid & "','" & first_name.Text & "','" & last_name.Text & "','" & u_email.Text & "','" & u_password.Text & "','" & register_date & "')"
                    cmd = New SqlCommand(str_sql, conn)
                    cmd.ExecuteNonQuery()
                    Dim aCookie As New HttpCookie("user")
                    aCookie.Values("email") = u_email.Text
                    aCookie.Expires = DateTime.Now.AddDays(30)
                    Response.Cookies.Add(aCookie)
                    Response.Redirect("home.aspx")
                End If
            End If

        Catch ex As Exception
            error_msg.Text = ex.ToString()
        End Try
    End Sub
End Class