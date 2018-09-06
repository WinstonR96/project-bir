package co.com.bucompany.mascotapp.Core.Comandos

import co.com.bucompany.mascotapp.Core.Interfaces.IComando
import co.com.bucompany.mascotapp.Core.Interfaces.ISolicitud

public abstract class ComandoAbstract : IComando {
    constructor(solicitud : ISolicitud)

    override abstract fun Ejecutar()
}
