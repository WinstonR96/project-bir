package co.com.bucompany.mascotapp.Ui.Model


import co.com.bucompany.mascotapp.Core.Interfaces.IResultadoLogin
import co.com.bucompany.mascotapp.Entidades.Response.LoginResponse

class ModelResultadoLogin : IResultadoLogin {
    override var response: LoginResponse? = null


    companion object {
        @Volatile
        private var INSTANCE: ModelResultadoLogin?= null
        fun getInstance() =
                INSTANCE ?: synchronized(this){
                    INSTANCE ?: ModelResultadoLogin()
                }


    }
}