package co.com.bucompany.mascotapp.Core

import co.com.bucompany.mascotapp.Core.Comandos.CreadorComando
import co.com.bucompany.mascotapp.Core.Interfaces.IComando
import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud

class Agente {

    companion object {
        @Volatile
        private var INSTANCE: Agente?= null
        fun getInstance() =
                INSTANCE ?: synchronized(this){
                    INSTANCE ?: Agente()
                }


    }

    fun ProcesarComando(solicitud : ISolicitud){
        var comando : IComando = CreadorComando.GetComando(solicitud)
        comando.Ejecutar()
    }


}