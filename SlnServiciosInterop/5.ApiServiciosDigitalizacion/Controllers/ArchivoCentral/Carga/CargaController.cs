using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using EnServiciosDigitalizacion;
using EnServiciosDigitalizacion.Carga;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utilitarios.Excel;
using Utilitarios.Recursos;

namespace ApiServiciosDigitalizacion.Controllers.ArchivoCentral.Carga
{
    [EnableCors("ReglasCors")]
    [Route("api/archivo-central/carga")]
    public class CargaController : ControllerBase
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public CargaController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        [Route("procesar-excel")]
        public IActionResult CargarArchivo(IFormFile fileArchivo, long IdTabla, long IdUsuario, string UsuCreacion)
        {
            enAuditoria auditoria = new enAuditoria();
            string CODIGO_TEMPORAL = GenerarCodigo.GenerarCodigoTemporal();
            string RUTA_TEMPORAL = Rutas.Ruta_Temporal();
            string RUTA_ARCHIVO_TEMPORAL = string.Format("{0}{1}", CODIGO_TEMPORAL, Path.GetExtension(fileArchivo.FileName));
            //RUTA_ARCHIVO_TEMPORAL = string.Format("{0}/{1}_{2}", RUTA_TEMPORAL, cls_Ent_Control_Carga.ID_CONTROL_CARGA, CODIGO_TEMPORAL + EXTENSION);
             //RUTA_TEMPORAL = Path.Combine(webHostEnvironment.WebRootPath, "Temporales");
            //fileArchivo.SaveAs(RUTA_ARCHIVO_TEMPORAL);
            string filePath = Path.Combine(RUTA_TEMPORAL, RUTA_ARCHIVO_TEMPORAL);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                fileArchivo.CopyTo(fileStream);
            }

            //if (fileArchivo != null)
            //{
            //    if (fileArchivo != null)
            //    {
            //        long ID_USUARIO = IdUsuario;
            //        string USU_CREACION = UsuCreacion;
            //        string IP_CREACION = IPUser.ObtenerIP();
            //        long ID_TABLA = IdUsuario;
            //        string MENSAJE_ERROR = "";
            //        bool VALIDO = true;
            //        string RUTA_ARCHIVO_TEMPORAL = "";
            //        try
            //        {
            //            Tabla cls_Ent_Tabla = _cls_Serv_Tabla.Listar_Uno(ID_TABLA);
            //            if (fileArchivo != null)
            //            {
            //                if (fileArchivo.Length > 0)
            //                {
            //                    //var content = new byte[fileArchivo.Length];
            //                    //fileArchivo.OpenReadStream(content, 0, fileArchivo.Length);
            //                    //string Nombre = Path.GetFileName(fileArchivo.FileName);
            //                    string EXTENSION = Path.GetExtension(fileArchivo.FileName);
            //                    //if (Nombre == Nomarc)
            //                    {
            //                        // Registramos el control de carga para este proceso
            //                        ControlCarga cls_Ent_Control_Carga = _cls_Serv_Control_Carga.Registrar(new ControlCarga
            //                        {
            //                            ID_TABLA = ID_TABLA,
            //                            NRO_REGISTROS = 0,
            //                            USU_CREACION = USU_CREACION,
            //                            IP_CREACION = IP_CREACION,
            //                            ID_USUARIO = ID_USUARIO
            //                        }, ref auditoria);
            //                        if (auditoria.EjecucionProceso)
            //                        {
            //                            if (!auditoria.Rechazo)
            //                            {
            //                                if (!EXTENSION.Equals(".xls") && !EXTENSION.Equals(".xlsx"))
            //                                {
            //                                    VALIDO = false;
            //                                    MENSAJE_ERROR = "La extensión del archivo debe ser (.xls) o (.xlsx)";
            //                                    auditoria = this.Carga_ErrorRegistrar(cls_Ent_Control_Carga.ID_CONTROL_CARGA, MENSAJE_ERROR, USU_CREACION, IP_CREACION, 0, auditoria);
            //                                }
            //                                if (VALIDO)
            //                                {
            //                                    string CODIGO_TEMPORAL = GenerarCodigo.GenerarCodigoTemporal();
            //                                    string RUTA_TEMPORAL = Rutas.Ruta_Temporal();
            //                                    RUTA_ARCHIVO_TEMPORAL = string.Format("{1}{2}", CODIGO_TEMPORAL, EXTENSION);
            //                                    //RUTA_ARCHIVO_TEMPORAL = string.Format("{0}/{1}_{2}", RUTA_TEMPORAL, cls_Ent_Control_Carga.ID_CONTROL_CARGA, CODIGO_TEMPORAL + EXTENSION);

            //                                    //fileArchivo.SaveAs(RUTA_ARCHIVO_TEMPORAL);
            //                                    string filePath = Path.Combine(RUTA_TEMPORAL, RUTA_ARCHIVO_TEMPORAL);
            //                                    using (var fileStream = new FileStream(filePath, FileMode.Create))
            //                                    {
            //                                        fileArchivo.CopyTo(fileStream);
            //                                    }

            //                                    IEnumerable<Campo> CAMPOS = _cls_Serv_Campo.Listar_Todo(ID_TABLA, ref auditoria);
            //                                    if (auditoria.EjecucionProceso)
            //                                    {
            //                                        if (!auditoria.Rechazo)
            //                                        {
            //                                            List<Campo> LISTA_CAMPOS = CAMPOS.OrderBy(x => x.NRO_CAMPO).ToList();
            //                                            auditoria = CargarArchivoFormato(cls_Ent_Control_Carga.ID_CONTROL_CARGA, RUTA_ARCHIVO_TEMPORAL, LISTA_CAMPOS, USU_CREACION, auditoria);
            //                                            if (auditoria.EjecucionProceso)
            //                                            {
            //                                                if (!auditoria.Rechazo)
            //                                                {
            //                                                    CargaEx cls_Ent_Carga = (CargaEx)auditoria.Objeto;

            //                                                    String[] array = new String[LISTA_CAMPOS.Count() + 1];
            //                                                    for (int i = 0; i < LISTA_CAMPOS.Count(); i++)
            //                                                    {
            //                                                        array[i] = LISTA_CAMPOS[i].COD_CAMPO.Trim();
            //                                                    }
            //                                                    array[LISTA_CAMPOS.Count()] = "NRO_LINEA";

            //                                                    _cls_Serv_Control_Carga.Registrar_Carga(cls_Ent_Tabla.COD_TABLA_TEMPORAL, cls_Ent_Carga.TABLA, array, ref auditoria);
            //                                                    if (auditoria.EjecucionProceso)
            //                                                    {
            //                                                        if (!auditoria.Rechazo)
            //                                                        {
            //                                                            int Lista_cargada = _cls_Serv_Documento_Temporal.Documento_Temporal_Cuenta(cls_Ent_Control_Carga.ID_CONTROL_CARGA, ref auditoria);
            //                                                            if (auditoria.EjecucionProceso)
            //                                                            {
            //                                                                if (!auditoria.Rechazo)
            //                                                                {
            //                                                                    if (Lista_cargada != cls_Ent_Carga.CANTIDAD_FILAS)
            //                                                                    {
            //                                                                        VALIDO = false;
            //                                                                        MENSAJE_ERROR = "La cantidad de archivos cargados no se subieron correctamente por error de configuración - Consulte con el encargado de sistemas si este error aparece";
            //                                                                        auditoria = this.Carga_ErrorRegistrar(cls_Ent_Control_Carga.ID_CONTROL_CARGA, MENSAJE_ERROR, USU_CREACION, IP_CREACION, 0, auditoria);
            //                                                                    }
            //                                                                    if (VALIDO)
            //                                                                    {
            //                                                                        auditoria.Limpiar();
            //                                                                        try
            //                                                                        {
            //                                                                            _cls_Serv_Carga.Carga_Validar(cls_Ent_Control_Carga.ID_CONTROL_CARGA, ID_TABLA, ref auditoria);
            //                                                                            if (auditoria.EjecucionProceso)
            //                                                                            {
            //                                                                                if (!auditoria.Rechazo)
            //                                                                                {
            //                                                                                    //auditoria.Objeto = cls_Ent_Control_Carga.ID_CONTROL_CARGA;
            //                                                                                }
            //                                                                            }
            //                                                                        }
            //                                                                        catch (Exception ex)
            //                                                                        {
            //                                                                            auditoria.Error(ex);
            //                                                                            VALIDO = false;
            //                                                                            MENSAJE_ERROR = auditoria.MensajeSalida;
            //                                                                            auditoria = this.Carga_ErrorRegistrar(cls_Ent_Control_Carga.ID_CONTROL_CARGA, MENSAJE_ERROR, USU_CREACION, IP_CREACION, 0, auditoria);
            //                                                                        }
            //                                                                    }
            //                                                                }
            //                                                            }
            //                                                        }
            //                                                    }
            //                                                }
            //                                            }
            //                                        }
            //                                    }
            //                                }
            //                                // Devolvemos el ID de la carga.
            //                                auditoria.Objeto = cls_Ent_Control_Carga.ID_CONTROL_CARGA;
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                auditoria.Rechazar("No se encontró ningun archivo, seleccione alguno");
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            auditoria.Error(ex);
            //        }
            //        finally
            //        {
            //            if (RUTA_ARCHIVO_TEMPORAL != "")
            //            {
            //                if (System.IO.File.Exists(RUTA_ARCHIVO_TEMPORAL))
            //                {
            //                    System.IO.File.Delete(RUTA_ARCHIVO_TEMPORAL);
            //                }
            //            }
            //            if (!auditoria.EjecucionProceso)
            //            {
            //                if (auditoria.Rechazo)
            //                {
            //                    string CODIGO = Log.Guardar(auditoria.MensajeSalida);
            //                    auditoria.MensajeSalida = Log.Mensaje(CODIGO);
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        auditoria.Rechazar("No se encontró ningun archivo, seleccione alguno");
            //    }
            //}
            //else
            //{
            //    auditoria.Rechazar("No se encontró ningun archivo, seleccione alguno");
            //}
            return StatusCode(auditoria.Code, auditoria);
        }

        private enAuditoria CargarArchivoFormato(long ID_CONTROL_CARGA, string RUTA_ARCHIVO_TEMPORAL, List<Campo> List_Cls_Ent_Campo, string USU_CREACION, enAuditoria auditoria)
        {
            //auditoria = this.Carga_LeerExcel(ID_CONTROL_CARGA, RUTA_ARCHIVO_TEMPORAL, List_Cls_Ent_Campo, USU_CREACION, auditoria);
            //if (auditoria.EjecucionProceso)
            //{
            //    if (!auditoria.Rechazo)
            //    {
            //        CargaEx cls_Ent_Carga = (CargaEx)auditoria.Objeto;
            //        int CANTIDAD_COLUMNAS = List_Cls_Ent_Campo.FindAll(x => x.FLG_CLASIFICACION == "F").Count;

            //        if (CANTIDAD_COLUMNAS != cls_Ent_Carga.CANTIDAD_COLUMNAS)
            //        {
            //            auditoria.Rechazar("El archivo cargado no tiene el número de columnas requeridas.");
            //        }
            //    }
            //}
            return auditoria;
        }

        //private enAuditoria Carga_LeerExcel(long ID_CONTROL_CARGA, string RUTA_ARCHIVO_TEMPORAL, List<Campo> List_Cls_Ent_Campo, string USU_CREACION, enAuditoria auditoria)
        //{
        //    auditoria.Limpiar();
        //    try
        //    {
        //        DataTable midt = ImportExcel.ExcelToDataTable(RUTA_ARCHIVO_TEMPORAL, 0, ref auditoria);
        //        if (auditoria.EjecucionProceso)
        //        {
        //            if (!auditoria.Rechazo)
        //            {
        //                string NombreHoja = "FormatoCarga";
        //                bool flgValidaNombre = false;
        //                if (midt.TableName == NombreHoja)
        //                {
        //                    flgValidaNombre = true;
        //                }
        //                if (flgValidaNombre == true)
        //                {
        //                    DataTable Dt = new DataTable();
        //                    try
        //                    {
        //                        DataSet tablesFromDB = new DataSet();
        //                        DataTable dt = new DataTable();
        //                        int col = 0;

        //                        dt.Columns.Add("NRO_LINEA", typeof(int));
        //                        dt.Columns["NRO_LINEA"].AutoIncrement = true;
        //                        dt.Columns["NRO_LINEA"].AutoIncrementSeed = 2;
        //                        dt.Columns["NRO_LINEA"].AutoIncrementStep = 1;
        //                        dt.Columns["NRO_LINEA"].Prefix = "BD";

        //                        col++;
        //                        int colh = 0;
        //                        int columnas_restar = 1;
        //                        foreach (Campo campo in List_Cls_Ent_Campo)
        //                        {
        //                            if (campo.FLG_CLASIFICACION == "S")
        //                            {
        //                                columnas_restar++;
        //                                if (campo.FLG_AUTOINCREMENT == "1")
        //                                {
        //                                    long valor = 1;
        //                                    try
        //                                    {
        //                                        valor = _cls_Serv_Campo.Ejecutar_Query(campo.QUERY_CAMPO, ref auditoria);
        //                                    }
        //                                    catch
        //                                    {
        //                                        valor = 1;
        //                                    }
        //                                    dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(int));
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].AutoIncrement = true;
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].AutoIncrementSeed = valor;
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].AutoIncrementStep = 1;
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                                }
        //                                else
        //                                {
        //                                    dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(string));
        //                                    if (campo.COD_CAMPO.Trim() == "ID_CONTROL_CARGA")
        //                                    {
        //                                        dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = ID_CONTROL_CARGA;
        //                                    }
        //                                    else
        //                                    {
        //                                        dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = "";
        //                                    }
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                                }
        //                            }
        //                            else if (campo.FLG_CLASIFICACION == "A")
        //                            {
        //                                columnas_restar++;
        //                                // SE AÑADEN COLUMNAS DE AUDITORIA
        //                                if (campo.COD_CAMPO.Trim() == "FLG_ESTADO")
        //                                {
        //                                    dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(string));
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = "1";
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                                }
        //                                if (campo.COD_CAMPO.Trim() == "USU_CREACION")
        //                                {
        //                                    dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(string));
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = USU_CREACION;
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                                }
        //                                else if (campo.COD_CAMPO.Trim() == "FEC_CREACION")
        //                                {
        //                                    dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(DateTime));
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = DateTime.Now; // String.Format("{0:dd/MM/yyyy HH:mm:ss}", DateTime.Now);//.ToString("HH:mm");

        //                                    dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                                }
        //                                else if (campo.COD_CAMPO.Trim() == "IP_CREACION")
        //                                {
        //                                    dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(string));
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = IPUser.ObtenerIP();
        //                                    dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                                }
        //                            }
        //                            else if (campo.FLG_CLASIFICACION == "H")
        //                            {
        //                                columnas_restar++;
        //                                colh = colh + 1;
        //                                dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(string));
        //                                dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = "";
        //                                dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                            }
        //                        }

        //                        foreach (Campo campo in List_Cls_Ent_Campo)
        //                        {
        //                            DataColumnCollection columns = dt.Columns;
        //                            if (!columns.Contains(campo.COD_CAMPO.Trim()) && campo.FLG_CLASIFICACION == "W") // Si no existe la columna
        //                            {
        //                                dt.Columns.Add(campo.COD_CAMPO.Trim(), typeof(string));
        //                                dt.Columns[campo.COD_CAMPO.Trim()].Prefix = "BD";
        //                                dt.Columns[campo.COD_CAMPO.Trim()].DefaultValue = "";
        //                            }
        //                        }

        //                        int conteocol = dt.Columns.Count + 1;
        //                        foreach (DataColumn miscol in midt.Columns)
        //                        {
        //                            dt.Columns.Add(miscol.ColumnName.Trim(), typeof(string));
        //                            dt.Columns[miscol.ColumnName.Trim()].Prefix = "BD";
        //                        }
        //                        foreach (DataRow row in midt.Rows)
        //                        {
        //                            DataRow drx;
        //                            drx = dt.NewRow();

        //                            foreach (DataColumn miscol in midt.Columns)
        //                            {
        //                                drx[miscol.ColumnName.Trim()] = row[miscol.ColumnName.Trim()].ToString();
        //                            }

        //                            dt.Rows.Add(drx);
        //                        }
        //                        int iColCount = dt.Columns.Count;
        //                        dt.Columns["FLG_ESTADO"].SetOrdinal(iColCount - 1);
        //                        dt.Columns["USU_CREACION"].SetOrdinal(iColCount - 1);
        //                        dt.Columns["FEC_CREACION"].SetOrdinal(iColCount - 1);
        //                        dt.Columns["IP_CREACION"].SetOrdinal(iColCount - 1);
        //                        dt.Columns["NRO_LINEA"].SetOrdinal(iColCount - 1);
        //                        int columna = 0;
        //                        foreach (Campo campo in List_Cls_Ent_Campo)
        //                        {
        //                            if (campo.TIPO_CAMPO == "1" && campo.FLG_CLASIFICACION == "F") // Si es fila
        //                            {
        //                                //cuenta_legal_ayuda++;
        //                                dt.Columns[columna].ColumnName = campo.COD_CAMPO.Trim(); // La agregamos 
        //                                                                                         //dt.Columns[columna].Prefix = "BD";
        //                            }
        //                            columna++;
        //                        }
        //                        DataTable otradt1 = new DataTable();
        //                        otradt1 = dt.Clone();
        //                        otradt1.Merge(dt);

        //                        //DataColumnCollection columns = dt.Columns;
        //                        foreach (DataColumn miscol in dt.Columns)
        //                        {
        //                            if (miscol.Prefix != "BD")
        //                            {
        //                                otradt1.Columns.Remove(miscol.ColumnName);
        //                            }
        //                        }
        //                        dt = otradt1;
        //                        CargaEx cls_Ent_Carga = new CargaEx();
        //                        cls_Ent_Carga.TABLA = dt;
        //                        cls_Ent_Carga.CANTIDAD_COLUMNAS = dt.Columns.Count - columnas_restar;
        //                        cls_Ent_Carga.CANTIDAD_FILAS = int.Parse(dt.Rows.Count.ToString());
        //                        auditoria.Objeto = cls_Ent_Carga;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        auditoria.Error(ex);
        //                    }
        //                }
        //                else
        //                {
        //                    auditoria.Rechazar("El nombre de la hoja de excel tiene que ser 'FormatoCarga'.");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        auditoria.Error(ex);
        //    }
        //    return auditoria;
        //}

    }
}
