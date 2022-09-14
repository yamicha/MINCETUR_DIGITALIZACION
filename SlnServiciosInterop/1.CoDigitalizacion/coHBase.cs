using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoServiciosDigitalizacion
{
    public class coHBase : IDisposable
    {
        private bool disposedValue = false;
        // IDisposable
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: Liberar recursos administrados cuando se llamen explícitamente
                }

                // TODO: Liberar recursos no administrados compartidos
            }
            disposedValue = true;
        }


        #region IDisposable Support
        // C# agregó este código para implementar correctamente el modelo descartable.
        public void Dispose()
        {
            // No cambie este código. Coloque el código de limpieza en Dispose (disposing que se dispone como Boolean).
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
