package co.com.bucompany.mascotapp.Core.Comandos

import co.com.bucompany.mascotapp.Core.Entorno
import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud
import co.com.bucompany.mascotapp.Core.Solicitudes.SolVentanaDashboard

class CmdVentanaDashboard: ComandoAbstract {
    var solventanadashboard : SolVentanaDashboard ?= null

    constructor(solicitud : ISolicitud) : super(solicitud){
        solventanadashboard = solicitud as SolVentanaDashboard
    }

    override fun Ejecutar() {
        Entorno.getInstance().Vista!!.MostrarVentanaDashboard(solventanadashboard?.c, solventanadashboard?.Lr)
    }
}