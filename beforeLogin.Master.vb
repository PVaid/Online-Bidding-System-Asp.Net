Public Class beforeLogin
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim userCookie As HttpCookie = Request.Cookies("user")
        If userCookie IsNot Nothing Then
            Response.Redirect("home.aspx")
        End If
    End Sub

End Class