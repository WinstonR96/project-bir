package co.com.bucompany.mascotapp.Entidades.Request

data class LoginRequest(
        val Usuario : String,
        val Contrasena : String,
        val Email : String
)