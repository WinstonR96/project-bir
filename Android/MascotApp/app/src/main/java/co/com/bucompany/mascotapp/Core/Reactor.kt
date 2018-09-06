package co.com.bucompany.mascotapp.Core

import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud

class Reactor constructor() {
    companion object {
        @Volatile
        private var INSTANCE: Reactor?= null
        fun getInstance() =
                INSTANCE ?: synchronized(this){
                    INSTANCE ?: Reactor()
                }
    }

    fun ProcesarSolicitud(solicitud : ISolicitud){
       Agente.getInstance().ProcesarComando(solicitud)
    }
}