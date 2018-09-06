package co.com.bucompany.mascotapp.Core.Comandos

import co.com.bucompany.mascotapp.Core.Entorno
import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud
import co.com.bucompany.mascotapp.Core.Solicitudes.SolVentanaLogin

public class CmdVentanaLogin : ComandoAbstract{

    var solventanalogin : SolVentanaLogin ?= null;

    constructor(solicitud : ISolicitud) : super(solicitud){
        solventanalogin = solicitud as SolVentanaLogin
    }

    override fun Ejecutar(){
        Entorno.getInstance().Vista!!.MostrarVentanaLogin(solventanalogin!!.c)
    }
}