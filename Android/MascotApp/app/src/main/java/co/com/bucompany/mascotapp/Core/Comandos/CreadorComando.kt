package co.com.bucompany.mascotapp.Core.Comandos

import android.widget.Switch
import co.com.bucompany.mascotapp.Core.Enums.Triggers
import co.com.bucompany.mascotapp.Core.Interfaces.IComando
import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud

public class CreadorComando {
    companion object {
        fun GetComando(solicitud : ISolicitud) : IComando {
            var comando : IComando ?= null
            when(solicitud.Trigger){
                Triggers.Login -> {
                    comando = CmdVentanaLogin(solicitud)
                }
                Triggers.VentanaDashboard -> {
                    comando = CmdVentanaDashboard(solicitud)
                }


            }
            return comando!!
        }
    }

}