package co.com.bucompany.mascotapp.Entidades

data class Usuarios (
        val Id : String,
        val Usuario : String,
        val Email : String,
        val Contrasena : String,
        val Token : String,
        val Foto_Perfil : String,
        val Fecha_Creacion : String,
        val Rol : String,
        val Estado : String
)