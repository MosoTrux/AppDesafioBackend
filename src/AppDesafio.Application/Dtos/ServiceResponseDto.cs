using System.Collections.Generic;

namespace AppDesafio.Application.Dtos
{
    public class ServiceResponseDto<TData> where TData : class
    {
        /// <summary>
        ///     Inicializa una nueva instancia de la clase <see cref="T:ServiceResponseDto"/>.
        /// </summary>
        public ServiceResponseDto()
        {
            Messages = new List<string>();
        }

        /// <summary>
        ///     Indicador de proceso satisfactorio.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        ///     Lista de mensajes devueltos por el servicio de aplicación.
        /// </summary>
        public ICollection<string> Messages { get; set; }

        /// <summary>
        ///     Datos que ha generado el servicio de aplicación. 
        /// </summary>
        /// <remarks>Normalmente si se ha producido un error devolverá null.</remarks>
        public TData Data { get; set; }

    }
}
