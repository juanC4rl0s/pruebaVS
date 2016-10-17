using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Text.RegularExpressions;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;
using A = DocumentFormat.OpenXml.Drawing;
using DW = DocumentFormat.OpenXml.Drawing.Wordprocessing;
using PIC = DocumentFormat.OpenXml.Drawing.Pictures;

//using DAL;
using SDC = Spire.Doc;

using System.Linq;
using System.Text;

using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data.OleDb;
using System.Runtime.Serialization;
using System.Globalization;
using OfficeOpenXml;
//using SDC = Spire.Doc;
using Spire.Pdf;
using Spire.Pdf.Graphics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.IO.Packaging;
using System.Linq;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BLL
{
    public class GeneradorPdf
    {
        public static void generarCertificado(string IDENTIFICACION, String firma, string nombredeldocumento, string PlantillaCertificado, string from, decimal IDUSUARIO)
        {
            
            try
            {
                #region DEFINICIONES GENERALES DEL METODO

                String documentoPLANTILLA = PlantillaCertificado;

                #region copiar la plantilla

                String destino_file = String.Empty;
                String destino_filePDF = String.Empty;
                String plantilla_file = String.Empty;

                String Nombredocumentosolitopdf = nombredeldocumento.Replace(".docx", ".pdf");

                destino_file = ConfigurationManager.AppSettings["RutaWebSoftDoc"] + ConfigurationManager.AppSettings["RutaDescargas"] + nombredeldocumento;
                destino_filePDF = ConfigurationManager.AppSettings["RutaWebSoftDoc"] + ConfigurationManager.AppSettings["RutaDescargas"] + Nombredocumentosolitopdf;
                plantilla_file = ConfigurationManager.AppSettings["RutaWebSoftDoc"] + ConfigurationManager.AppSettings["RutaPlantillas"] + PlantillaCertificado;

                string sourceFile = plantilla_file;
                string destFile = destino_file;
                string destFilepdf = destino_filePDF;

                System.IO.File.Copy(sourceFile, destFile, true);

                #endregion

                #endregion

                #region consulta
                List<DCPERSONASCER> lstPERSONASCER = new List<DCPERSONASCER>();
                //DataTable DTPERSONASCER = new DataTable();
                //DTPERSONASCER = PERSONASCER.PERSONASCERObtenerbyCriterio(IDENTIFICACION, IDUSUARIO);
                lstPERSONASCER = PERSONASCER.PERSONASCERObtenerbyCriterio(IDENTIFICACION, IDUSUARIO);

                //for (int i = 0; i < DTPERSONASCER.Rows.Count; i++)
                //{
                //    lstPERSONASCER.Add
                //    (
                //        new DCPERSONASCER
                //        (
                //        Convert.ToDecimal(DTPERSONASCER.Rows[i]["IDPERSONA"].Equals(System.DBNull.Value) ? 0 : DTPERSONASCER.Rows[i]["IDPERSONA"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["IDENTIFICACION"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["IDENTIFICACION"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["NOMBRE"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["NOMBRE"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["APELLIDOS"]),
                //            Convert.ToDateTime(DTPERSONASCER.Rows[i]["FECHANACIMIENTO"].Equals(System.DBNull.Value) ? new DateTime() : DTPERSONASCER.Rows[i]["FECHANACIMIENTO"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["EMAIL"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["EMAIL"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["TELEFONO"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["TELEFONO"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["MOVIL"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["MOVIL"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["TIPO"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["TIPO"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["ESTADOCIVIL"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["ESTADOCIVIL"]),
                //            Convert.ToDecimal(DTPERSONASCER.Rows[i]["IDUSUARIOCREO"].Equals(System.DBNull.Value) ? 0 : DTPERSONASCER.Rows[i]["IDUSUARIOCREO"]),
                //            Convert.ToDateTime(DTPERSONASCER.Rows[i]["FECHACREO"].Equals(System.DBNull.Value) ? new DateTime() : DTPERSONASCER.Rows[i]["FECHACREO"]),
                //            Convert.ToDecimal(DTPERSONASCER.Rows[i]["IDUSUARIOMODIFICO"].Equals(System.DBNull.Value) ? 0 : DTPERSONASCER.Rows[i]["IDUSUARIOCREO"]),
                //            Convert.ToDateTime(DTPERSONASCER.Rows[i]["FECHAMODIFICO"].Equals(System.DBNull.Value) ? new DateTime() : DTPERSONASCER.Rows[i]["FECHAMODIFICO"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["CARGO"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["CARGO"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["DEPENDENCIA"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["DEPENDENCIA"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["FUNCIONES"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["FUNCIONES"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["SUELDO"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["SUELDO"]),
                //            (System.String)(DTPERSONASCER.Rows[i]["ACTIVO"].Equals(System.DBNull.Value) ? "" : DTPERSONASCER.Rows[i]["ACTIVO"])
                //            )
                //    );
                //}
                #endregion

                if (lstPERSONASCER.Count > 0)
                {

                    switch (from)
                    {
                        case "CERTIFICADO":

                            using (WordprocessingDocument package = WordprocessingDocument.Open(destFile, true))
                            {
                                String docText = String.Empty;
                                using (StreamReader sr = new StreamReader(package.MainDocumentPart.GetStream()))
                                {
                                    docText = sr.ReadToEnd();
                                }

                                Regex regexText = null;

                                #region Reemplazos

                                string fechanueva;

                                fechanueva = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString();

                                regexText = new Regex("C0D1G01NCR3M3NT4L");
                                docText = regexText.Replace(docText, (DateTime.Now.Millisecond + DateTime.Now.Second).ToString());

                                regexText = new Regex("F3CH4");
                                docText = regexText.Replace(docText, fechanueva.ToString());

                                regexText = new Regex("H0R4");
                                docText = regexText.Replace(docText, (DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second).ToString());

                                regexText = new Regex("N0MBR3P3RS0N4");
                                docText = regexText.Replace(docText, (lstPERSONASCER[0].NOMBRE + " " + lstPERSONASCER[0].APELLIDOS).ToString());

                                regexText = new Regex("1D3NT1F1C4CI0N");
                                docText = regexText.Replace(docText, lstPERSONASCER[0].IDENTIFICACION);

                                regexText = new Regex("F3CHA1NGR3S0");
                                docText = regexText.Replace(docText, lstPERSONASCER[0].FECHANACIMIENTO.ToShortDateString());

                                regexText = new Regex("C4RG0");
                                docText = regexText.Replace(docText, lstPERSONASCER[0].CARGO);

                                regexText = new Regex("D3P3ND3NC14");
                                docText = regexText.Replace(docText, lstPERSONASCER[0].DEPENDENCIA);

                                regexText = new Regex("FUNC10N35");
                                docText = regexText.Replace(docText, lstPERSONASCER[0].FUNCIONES);

                                regexText = new Regex("SU3LD0");
                                docText = regexText.Replace(docText, lstPERSONASCER[0].SUELDO);

                                #endregion

                                using (StreamWriter sw = new StreamWriter(package.MainDocumentPart.GetStream(FileMode.Create)))
                                {
                                    sw.Write(docText);

                                }

                                if (firma != String.Empty)
                                {
                                    String rutafirma = ConfigurationManager.AppSettings["RutaWebSoftDoc"] + ConfigurationManager.AppSettings["RutaFirmas"] + "1095808196" + ".jpg"; 

                                    MainDocumentPart mainPart = package.MainDocumentPart;

                                    ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
                                    using (FileStream stream = new FileStream(rutafirma, FileMode.Open))
                                    {
                                        imagePart.FeedData(stream);
                                    }

                                    GeneradorPdf.AddImageToBody(package, mainPart.GetIdOfPart(imagePart));
                                }

                                package.Close();
                                package.Dispose();

                                #region GUARDAR PDF

                                SDC.Document docSDC = new SDC.Document();
                                docSDC.LoadFromFile(destFile);
                                docSDC.SaveToFile(destFilepdf, SDC.FileFormat.PDF);

                                #endregion

                                Correos c = new Correos();
                                c.enviarCorreo("gabrielortegaandrade@hotmail.com", "uis2080077", "Usted ha solicitado un certificado, verifique el adjunto", "Certificado", lstPERSONASCER[0].EMAIL, destino_filePDF);
                            }

                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write("<script>alert('ha fallado el metodo de generar el documento!');</script>");
                
                String NobredelDocumentoError = @"h:\\root\\home\\sofgreendoc-001\\www\\softgreendoc\\tmp\\error_gen_docx.txt";
                String texto = ex.Message + " " + " " + ex.StackTrace + " " + ex.InnerException;

                System.IO.StreamWriter sw = new System.IO.StreamWriter(NobredelDocumentoError);
                sw.WriteLine(texto);
                sw.Close();
            }
        }

        private static void AddImageToBody(WordprocessingDocument wordDoc, string relationshipId)
        {
            // Define the reference of the image.
            var element =
                 new Drawing(
                     new DW.Inline(
                         new DW.Extent() { Cx = 1450000L, Cy = 792000L },
                         new DW.EffectExtent()
                         {
                             LeftEdge = 0L,
                             TopEdge = 0L,
                             RightEdge = 0L,
                             BottomEdge = 0L
                         },
                         new DW.DocProperties()
                         {
                             Id = (UInt32Value)1U,
                             Name = "Picture 1"
                         },
                         new DW.NonVisualGraphicFrameDrawingProperties(
                             new A.GraphicFrameLocks() { NoChangeAspect = true }),
                         new A.Graphic(
                             new A.GraphicData(
                                 new PIC.Picture(
                                     new PIC.NonVisualPictureProperties(
                                         new PIC.NonVisualDrawingProperties()
                                         {
                                             Id = (UInt32Value)0U,
                                             Name = "New Bitmap Image.jpg"
                                         },
                                         new PIC.NonVisualPictureDrawingProperties()),
                                     new PIC.BlipFill(
                                         new A.Blip(
                                             new A.BlipExtensionList(
                                                 new A.BlipExtension()
                                                 {
                                                     Uri =
                                                       "{28A0092B-C50C-407E-A947-70E740481C1C}"
                                                 })
                                         )
                                         {
                                             Embed = relationshipId,
                                             CompressionState =
                                             A.BlipCompressionValues.Print
                                         },
                                         new A.Stretch(
                                             new A.FillRectangle())),
                                     new PIC.ShapeProperties(
                                         new A.Transform2D(
                                             new A.Offset() { X = 0L, Y = 0L },
                                             new A.Extents() { Cx = 1450000L, Cy = 792000L }),
                                         new A.PresetGeometry(
                                             new A.AdjustValueList()
                                         ) { Preset = A.ShapeTypeValues.Rectangle }))
                             ) { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
                     )
                     {
                         DistanceFromTop = (UInt32Value)0U,
                         DistanceFromBottom = (UInt32Value)0U,
                         DistanceFromLeft = (UInt32Value)0U,
                         DistanceFromRight = (UInt32Value)0U,
                         EditId = "50D07946"
                     });

            // Append the reference to body, the element should be in a Run.
            wordDoc.MainDocumentPart.Document.Body.AppendChild(new Paragraph(new Run(element)));
        }
   
        #region
        //private String ROTULO = String.Empty;
        
        //#region Metodos

        //public static void generardocOpenXML(decimal iddoc, string usuario, decimal idusuario, string documento, string from)
        //{
        //    try
        //    {
        //        List<DCFUNCIONARIOS> lstFUNCIONARIO = new List<DCFUNCIONARIOS>();
        //        DataTable DTFUNCIONARIO = new DataTable();
        //        DTFUNCIONARIO = FUNCIONARIOS.FUNCIONARIOSObtenerbyIDFUNCIONARIO(idusuario, usuario, idusuario);

        //        for (int i = 0; i < DTFUNCIONARIO.Rows.Count; i++)
        //        {
        //            lstFUNCIONARIO.Add
        //            (
        //                new DCFUNCIONARIOS
        //                (
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDFUNCIONARIO"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["NOMBRES"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["NOMBRES"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["APELLIDOS"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["LOGIN"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["LOGIN"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["PASS"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["PASS"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["PERFILES"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["PERFILES"]),
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDSUCURSAL"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["SUCURSAL"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["SUCURSAL"]),
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDCENTROCOSTO"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["CENTROCOSTO"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["CENTROCOSTO"]),
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDUNIDADADMINISTRATIVA"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["UNIDADADMINISTRATIVA"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["UNIDADADMINISTRATIVA"]),
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDOFICINAPRODUCTORA"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["OFICINAPRODUCTORA"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["OFICINAPRODUCTORA"]),
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDCARGO"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["CARGO"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["CARGO"]),
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDNIVEL"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["NIVEL"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["NIVEL"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FOTO"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FOTO"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["EMAIL"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["EMAIL"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["ESTADO"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["ESTADO"]),
        //                    (System.Decimal)(DTFUNCIONARIO.Rows[i]["IDUSUARIO"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["USUARIO"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["USUARIO"]),
        //                    Convert.ToDateTime(DTFUNCIONARIO.Rows[i]["FECHAGRABO"].Equals(System.DBNull.Value) ? new DateTime(190, 1, 1) : DTFUNCIONARIO.Rows[i]["FECHAGRABO"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["NOMBRESAPELLIDOS"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["NOMBRESAPELLIDOS"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMA"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMA"]),
        //                    0, String.Empty, true, String.Empty,
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMAP12"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMAP12"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMATOKEN"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMATOKEN"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["RUBRICA"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["RUBRICA"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMA1"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMA1"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMA2"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMA2"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMA3"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMA3"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["TELETRABAJO"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["TELETRABAJO"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMAP12PASS"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMAP12PASS"]),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["FIRMATOKENPASS"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["FIRMATOKENPASS"]),
        //                    Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["IDFUNCIONARIOREMPLAZO"].Equals(System.DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["IDFUNCIONARIOREMPLAZO"]),
        //                    (Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["IDFUNCIONARIOREMPLAZO"].Equals(System.DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["IDFUNCIONARIOREMPLAZO"]) == 0 ?
        //                    new DCFUNCIONARIOS(false) :
        //                    new DCFUNCIONARIOS()
        //                    {
        //                        IDFUNCIONARIO = Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["IDFUNCIONARIOREMPLAZO"].Equals(DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["IDFUNCIONARIOREMPLAZO"]),
        //                        NOMBRES = (String)(DTFUNCIONARIO.Rows[i]["R_NOMBRES"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_NOMBRES"]),
        //                        APELLIDOS = (String)(DTFUNCIONARIO.Rows[i]["R_APELLIDOS"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_APELLIDOS"]),
        //                        NOMBRESAPELLIDOS = (String)(DTFUNCIONARIO.Rows[i]["R_NOMBRESAPELLIDOS"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_NOMBRESAPELLIDOS"]),
        //                        LOGIN = (String)(DTFUNCIONARIO.Rows[i]["R_LOGIN"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_LOGIN"]),
        //                        PERFILES = (String)(DTFUNCIONARIO.Rows[i]["R_PERFILES"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_PERFILES"]),
        //                        IDSUCURSAL = Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["R_IDSUCURSAL"].Equals(DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["R_IDSUCURSAL"]),
        //                        SUCURSAL = (String)(DTFUNCIONARIO.Rows[i]["R_SUCURSAL"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_SUCURSAL"]),
        //                        IDCENTROCOSTO = Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["R_IDCENTROCOSTO"].Equals(DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["R_IDCENTROCOSTO"]),
        //                        CENTROCOSTO = (String)(DTFUNCIONARIO.Rows[i]["R_CENTROCOSTO"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_CENTROCOSTO"]),
        //                        IDUNIDADADMINISTRATIVA = Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["R_IDUNIDADADMINISTRATIVA"].Equals(DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["R_IDUNIDADADMINISTRATIVA"]),
        //                        UNIDADADMINISTRATIVA = (String)(DTFUNCIONARIO.Rows[i]["R_UNIDADADMINISTRATIVA"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_UNIDADADMINISTRATIVA"]),
        //                        IDOFICINAPRODUCTORA = Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["R_IDOFICINAPRODUCTORA"].Equals(DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["R_IDOFICINAPRODUCTORA"]),
        //                        OFICINAPRODUCTORA = (String)(DTFUNCIONARIO.Rows[i]["R_OFICINAPRODUCTORA"].Equals(DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["R_OFICINAPRODUCTORA"]),
        //                        IDCARGO = Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["R_IDCARGO"].Equals(DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["R_IDCARGO"]),
        //                        CARGO = (String)(DTFUNCIONARIO.Rows[i]["R_CARGO"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_CARGO"]),
        //                        IDNIVEL = Convert.ToDecimal(DTFUNCIONARIO.Rows[i]["R_IDNIVEL"].Equals(DBNull.Value) ? 0 : DTFUNCIONARIO.Rows[i]["R_IDNIVEL"]),
        //                        NIVEL = (String)(DTFUNCIONARIO.Rows[i]["R_NIVEL"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_NIVEL"]),
        //                        FOTO = (String)(DTFUNCIONARIO.Rows[i]["R_FOTO"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FOTO"]),
        //                        EMAIL = (String)(DTFUNCIONARIO.Rows[i]["R_EMAIL"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_EMAIL"]),
        //                        FIRMA = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMA"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMA"]),
        //                        FIRMAP12 = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMAP12"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMAP12"]),
        //                        FIRMATOKEN = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMATOKEN"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMATOKEN"]),
        //                        RUBRICA = (String)(DTFUNCIONARIO.Rows[i]["R_RUBRICA"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_RUBRICA"]),
        //                        FIRMA1 = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMA1"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMA1"]),
        //                        FIRMA2 = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMA2"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMA2"]),
        //                        FIRMA3 = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMA3"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMA3"]),
        //                        TELETRABAJO = (String)(DTFUNCIONARIO.Rows[i]["R_TELETRABAJO"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_TELETRABAJO"]),
        //                        FIRMAP12PASS = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMAP12PASS"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMAP12PASS"]),
        //                        FIRMATOKENPASS = (String)(DTFUNCIONARIO.Rows[i]["R_FIRMATOKENPASS"].Equals(DBNull.Value) ? String.Empty : DTFUNCIONARIO.Rows[i]["R_FIRMATOKENPASS"])
        //                    }),
        //                    (System.String)(DTFUNCIONARIO.Rows[i]["PASS2"].Equals(System.DBNull.Value) ? "" : DTFUNCIONARIO.Rows[i]["PASS2"])
        //                )
        //            );
        //        }
        //        //DCFUNCIONARIOS usr =
        //        String firma = lstFUNCIONARIO[0].FIRMA;
        //        String rutafirma = ConfigurationManager.AppSettings["RutaFirmasM"] + firma;
                
        //        List<DCDOCUMENTOS> lstDOCUMENTO = new List<DCDOCUMENTOS>();
        //        DataTable DtDOCUMENTOCONSULTADO = new DataTable();
        //        //buscar el idtipodoc en docs
        //        DtDOCUMENTOCONSULTADO = DOCUMENTOS.DOCUMENTOSObtenerbyIDDOCUMENTOSOLO1(iddoc, usuario, idusuario);
        //        //DCDOCS doc = DOCS.DOCS_ObtenerbyIDDOC(iddoc, usuario, idusuario);

        //        for (int i = 0; i < DtDOCUMENTOCONSULTADO.Rows.Count; i++)
        //        {
        //            lstDOCUMENTO.Add
        //            (
        //                new DCDOCUMENTOS
        //                (Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDDOCUMENTO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDDOCUMENTO"]),
        //            Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUNIDADADMINISTRATIVA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUNIDADADMINISTRATIVA"]),
        //            (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["UNIDADADMINISTRATIVA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["UNIDADADMINISTRATIVA"]),
        //            Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDOFICINAPRODUCTORA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDOFICINAPRODUCTORA"]),
        //            (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["OFICINAPRODUCTORA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["OFICINAPRODUCTORA"]),
        //            Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDSERIE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDSERIE"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["SERIE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["SERIE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDSUBSERIE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDSUBSERIE"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["SUBSERIE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["SUBSERIE"]),
        //    Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL"]),
        //             (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["TIPOLOGIADOCUMENTAL"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["TIPOLOGIADOCUMENTAL"]),
        //    Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRDC"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRDC"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRD"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRD"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDEXPEDIENTE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDEXPEDIENTE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDZONA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDZONA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDSUCURSAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDSUCURSAL"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDCENTROCOSTO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDCENTROCOSTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDCLASE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDCLASE"]),
        //     (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["CLASE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["CLASE"]),
        //    Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ANO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ANO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["SECUENCIA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["SECUENCIA"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["RADICADO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["RADICADO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDGESTORLIDER"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDGESTORLIDER"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["GESTORNOMBRESAPELLIDOS"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["GESTORNOMBRESAPELLIDOS"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["DESCRIPCION"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHACREACION"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHACREACION"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOCREACION"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOCREACION"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOCREACION"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOCREACION"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIORADICO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIORADICO"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["FUNCIONARIORADICO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["FUNCIONARIORADICO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIORADICO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIORADICO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ORDEN"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ORDEN"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["TOMO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["TOMO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOINICIAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOINICIAL"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOFINAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOFINAL"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["NROFOLIOS"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["NROFOLIOS"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDMEDIORECEPCION"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDMEDIORECEPCION"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDPAIS"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDPAIS"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDDEPARTAMENTO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDDEPARTAMENTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDMUNICIPIO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDMUNICIPIO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["DOCUMENTOID"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["DOCUMENTOID"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDANEXO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDANEXO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["ANEXODETALLE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["ANEXODETALLE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ANEXONUMERO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ANEXONUMERO"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAANULO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAANULO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOANULO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOANULO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOANULO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOANULO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["MOTIVOANULO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["MOTIVOANULO"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAVENCIMIENTO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAVENCIMIENTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["DIASVENCE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["DIASVENCE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["HORASVENCE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["HORASVENCE"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["CERRADO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["CERRADO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["ORIGEN"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["ORIGEN"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NROEXPEDIENTE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NROEXPEDIENTE"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["PRIORIDAD"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["PRIORIDAD"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["VALOR_CADUCE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["VALOR_CADUCE"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICACION_MANUAL"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICACION_MANUAL"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["COLOR"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["COLOR"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDRUTA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDRUTA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDPLANILLADIST"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDPLANILLADIST"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ORDENPLANILLA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ORDENPLANILLA"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["HUELLA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["HUELLA"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["ESTADO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["ESTADO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIO"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAGRABO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAGRABO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTOMO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTOMO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDCUADERNO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDCUADERNO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACION"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACION"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["PROCESO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["PROCESO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["TIPOPROCESO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["TIPOPROCESO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["TIPOCONTRATO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["TIPOCONTRATO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["SEGMENTO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["SEGMENTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["SALDO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["SALDO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACIONTIPO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACIONTIPO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NROGUIA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NROGUIA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDPARENTESCO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDPARENTESCO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDESTADOPENSION"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDESTADOPENSION"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDNATURALEZA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDNATURALEZA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDRADICADOWEBSERVICE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDRADICADOWEBSERVICE"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAHORADIGITALIZO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAHORADIGITALIZO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIODIGITALIZO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIODIGITALIZO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIODIGITALIZO"].Equals(System.DBNull.Value) ? "0" : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIODIGITALIZO"])
        //               )
        //            );
        //        }
                
        //        String destino_file = String.Empty;

        //        switch (from)
        //        {
        //            case "GENERAR.DOC.GESTION":
        //            case "GENERAR.DOC.PROYECCION":

        //                destino_file = ConfigurationManager.AppSettings["RutaFormatosDocs"] + documento;

        //                using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destino_file, true))
        //                {
        //                    String docText = String.Empty;
        //                    using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
        //                    {
        //                        docText = sr.ReadToEnd();
        //                    }


        //                    Regex regexText = null;

        //                    #region Reemplazos

        //                    string fechanueva;

        //                    fechanueva = lstDOCUMENTO[0].FECHARADICO.Day.ToString() + "/" + lstDOCUMENTO[0].FECHARADICO.Month.ToString() + "/" + lstDOCUMENTO[0].FECHARADICO.Year.ToString();

        //                    regexText = new Regex("FECH4");
        //                    docText = regexText.Replace(docText, fechanueva.ToString());

        //                    regexText = new Regex("NROFOLIOS");
        //                    docText = regexText.Replace(docText, lstDOCUMENTO[0].NROFOLIOS.ToString());


        //                    if (from == "GENERAR.DOC.GESTION")
        //                    {
        //                        regexText = new Regex("R@QTKADO");
        //                        docText = regexText.Replace(docText, lstDOCUMENTO[0].RADICADO);
        //                    }
        //                    else if (from == "GENERAR.DOC.PROYECCION")
        //                    {
        //                        if (docText.Contains("R@QTKADO"))
        //                        {
        //                            regexText = new Regex("R@QTKADO");
        //                            docText = regexText.Replace(docText, lstDOCUMENTO[0].RADICADO);
        //                        }
        //                        else if (docText.Contains("R@QTKADORTA"))
        //                        {
        //                            regexText = new Regex("R@QTKADORTA");
        //                            docText = regexText.Replace(docText, lstDOCUMENTO[0].RADICADO);
        //                        }
        //                        else
        //                        {
        //                            Body body = wordDoc.MainDocumentPart.Document.Body;

        //                            Paragraph para = body.AppendChild(new Paragraph());
        //                            Run run = para.AppendChild(new Run());
        //                            run.AppendChild(new Text(lstDOCUMENTO[0].RADICADO));
        //                            //wordDoc.Close();
        //                        }
        //                    }

        //                    regexText = new Regex("NROANEXOS");
        //                    docText = regexText.Replace(docText, lstDOCUMENTO[0].ANEXONUMERO.ToString());

        //                    //regexText = new Regex("TIPANEXO");
        //                    //docText = regexText.Replace(docText, doc.TIPOANEXO);

        //                    regexText = new Regex("ORIGHEN");
        //                    docText = regexText.Replace(docText, lstDOCUMENTO[0].UNIDADADMINISTRATIVA);

        //                    //regexText = new Regex("DHESTINO");
        //                    //docText = regexText.Replace(docText, lstDOCUMENTO[0].UA_OP_DESTINO);

        //                    regexText = new Regex("ASHUNTO");
        //                    docText = regexText.Replace(docText, lstDOCUMENTO[0].DESCRIPCION);


        //                    regexText = new Regex("CIUD4DYFECH4");
        //                    docText = regexText.Replace(docText, lstDOCUMENTO[0].IDMUNICIPIO + ", " + DateTime.Now.ToLongDateString());

        //                    //regexText = new Regex("DHESTIN@TARYO");
        //                    //docText = regexText.Replace(docText, lstDOCUMENTO[0].DESTINATARIO);

        //                    //regexText = new Regex("ASUNTHO");
        //                    //docText = regexText.Replace(docText, lstDOCUMENTO[0].DESCRIPCION);

        //                    //regexText = new Regex("CIUD4DDESTI");
        //                    //docText = regexText.Replace(docText, lstDOCUMENTO[0].CIUDAD);

        //                    //regexText = new Regex("CONTENT");
        //                    //docText = regexText.Replace(docText, lstDOCUMENTO[0].DESCRIPCION);

        //                    //regexText = new Regex("FHIRWANT3");
        //                    //docText = regexText.Replace(docText, lstDOCUMENTO[0].FIRMANTE);

        //                    #endregion

        //                    using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
        //                    {
        //                        sw.Write(docText);
        //                    }

        //                    if (firma != String.Empty)
        //                    {
        //                        MainDocumentPart mainPart = wordDoc.MainDocumentPart;

        //                        ImagePart imagePart = mainPart.AddImagePart(ImagePartType.Jpeg);
        //                        using (FileStream stream = new FileStream(rutafirma, FileMode.Open))
        //                        {
        //                            imagePart.FeedData(stream);
        //                        }

        //                        OpenXMLLocal.AddImageToBody(wordDoc, mainPart.GetIdOfPart(imagePart));
        //                    }
        //                }

        //                break;
        //            default:
        //                break;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        String fic = @"c:\\tmp\\error_gen_docx.txt";
        //        String texto = ex.Message + " " + " " + ex.StackTrace + " " + ex.InnerException;

        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
        //        sw.WriteLine(texto);
        //        sw.Close();

        //        throw ex;
        //    }
        //}

        //public static void generardocOpenXMLpqr(decimal iddoc, string usuario, decimal idusuario, string documento, string from, String NIT)
        //{
        //    try
        //    {
        //        #region CONSULTADELDOCUMENTO

        //        List<DCDOCUMENTOS> lstDOCUMENTO = new List<DCDOCUMENTOS>();
        //        DataTable DtDOCUMENTOCONSULTADO = new DataTable();
        //        //buscar el idtipodoc en docs
        //        DtDOCUMENTOCONSULTADO = DOCUMENTOS.DOCUMENTOSObtenerbyIDDOCUMENTOSOLO1(iddoc, usuario, idusuario);
        //        //DCDOCS doc = DOCS.DOCS_ObtenerbyIDDOC(iddoc, usuario, idusuario);

        //        for (int i = 0; i < DtDOCUMENTOCONSULTADO.Rows.Count; i++)
        //        {
        //            lstDOCUMENTO.Add
        //            (
        //                new DCDOCUMENTOS
        //                (Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDDOCUMENTO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDDOCUMENTO"]),
        //            Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUNIDADADMINISTRATIVA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUNIDADADMINISTRATIVA"]),
        //            (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["UNIDADADMINISTRATIVA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["UNIDADADMINISTRATIVA"]),
        //            Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDOFICINAPRODUCTORA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDOFICINAPRODUCTORA"]),
        //            (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["OFICINAPRODUCTORA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["OFICINAPRODUCTORA"]),
        //            Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDSERIE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDSERIE"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["SERIE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["SERIE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDSUBSERIE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDSUBSERIE"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["SUBSERIE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["SUBSERIE"]),
        //    Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL"]),
        //             (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["TIPOLOGIADOCUMENTAL"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["TIPOLOGIADOCUMENTAL"]),
        //    Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRDC"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRDC"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRD"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTIPOLOGIADOCUMENTAL_TRD"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDEXPEDIENTE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDEXPEDIENTE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDZONA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDZONA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDSUCURSAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDSUCURSAL"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDCENTROCOSTO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDCENTROCOSTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDCLASE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDCLASE"]),
        //     (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["CLASE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["CLASE"]),
        //    Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ANO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ANO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["SECUENCIA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["SECUENCIA"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["RADICADO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["RADICADO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDGESTORLIDER"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDGESTORLIDER"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["GESTORNOMBRESAPELLIDOS"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["GESTORNOMBRESAPELLIDOS"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["DESCRIPCION"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["DESCRIPCION"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHACREACION"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHACREACION"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOCREACION"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOCREACION"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOCREACION"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOCREACION"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIORADICO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIORADICO"]),
        //    (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["FUNCIONARIORADICO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["FUNCIONARIORADICO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIORADICO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIORADICO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ORDEN"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ORDEN"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["TOMO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["TOMO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOINICIAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOINICIAL"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOFINAL"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["FOLIOFINAL"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["NROFOLIOS"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["NROFOLIOS"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDMEDIORECEPCION"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDMEDIORECEPCION"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDPAIS"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDPAIS"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDDEPARTAMENTO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDDEPARTAMENTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDMUNICIPIO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDMUNICIPIO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["DOCUMENTOID"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["DOCUMENTOID"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDANEXO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDANEXO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["ANEXODETALLE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["ANEXODETALLE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ANEXONUMERO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ANEXONUMERO"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAANULO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAANULO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOANULO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIOANULO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOANULO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIOANULO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["MOTIVOANULO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["MOTIVOANULO"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAVENCIMIENTO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAVENCIMIENTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["DIASVENCE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["DIASVENCE"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["HORASVENCE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["HORASVENCE"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["CERRADO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["CERRADO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["ORIGEN"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["ORIGEN"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NROEXPEDIENTE"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NROEXPEDIENTE"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["PRIORIDAD"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["PRIORIDAD"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["VALOR_CADUCE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["VALOR_CADUCE"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICACION_MANUAL"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHARADICACION_MANUAL"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["COLOR"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["COLOR"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDRUTA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDRUTA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDPLANILLADIST"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDPLANILLADIST"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["ORDENPLANILLA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["ORDENPLANILLA"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["HUELLA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["HUELLA"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["ESTADO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["ESTADO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIO"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAGRABO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAGRABO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDTOMO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDTOMO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDCUADERNO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDCUADERNO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACION"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACION"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["PROCESO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["PROCESO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["TIPOPROCESO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["TIPOPROCESO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["TIPOCONTRATO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["TIPOCONTRATO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["SEGMENTO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["SEGMENTO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["SALDO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["SALDO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACIONTIPO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NOTIFICACIONTIPO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["NROGUIA"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["NROGUIA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDPARENTESCO"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDPARENTESCO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDESTADOPENSION"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDESTADOPENSION"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDNATURALEZA"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDNATURALEZA"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDRADICADOWEBSERVICE"].Equals(System.DBNull.Value) ? 0 : DtDOCUMENTOCONSULTADO.Rows[i]["IDRADICADOWEBSERVICE"]),
        //                Convert.ToDateTime(DtDOCUMENTOCONSULTADO.Rows[i]["FECHAHORADIGITALIZO"].Equals(System.DBNull.Value) ? new DateTime(1900, 1, 1) : DtDOCUMENTOCONSULTADO.Rows[i]["FECHAHORADIGITALIZO"]),
        //                (System.String)(DtDOCUMENTOCONSULTADO.Rows[i]["USUARIODIGITALIZO"].Equals(System.DBNull.Value) ? "" : DtDOCUMENTOCONSULTADO.Rows[i]["USUARIODIGITALIZO"]),
        //                Convert.ToDecimal(DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIODIGITALIZO"].Equals(System.DBNull.Value) ? "0" : DtDOCUMENTOCONSULTADO.Rows[i]["IDUSUARIODIGITALIZO"])
        //               )
        //            );
        //        }

        //        #endregion

        //        #region DEFINICIONES GENERALES DEL METODO

        //        String documentoPLANTILLA = "PLANTILLAPQRWEB.docx";

        //        #region copiar la plantilla

        //        string sourcePath = ConfigurationManager.AppSettings["RutaFormatosDocsPQR"];
        //        string targetPath = ConfigurationManager.AppSettings["RutaFormatosDocsPQRreemplazo"];
        //        string targetPathpdf = ConfigurationManager.AppSettings["RutaFormatosDocsPQRreemplazoPDF"];

        //        String Nombredocumentosolitopdf = documento.Replace(".docx", ".pdf");

        //        //string sourceFile = System.IO.Path.Combine(sourcePath, documentoPLANTILLA);
        //        //string destFile = System.IO.Path.Combine(targetPath, documento.ToString());
        //        //string destFilepdf = System.IO.Path.Combine(targetPathpdf, Nombredocumentosolitopdf.ToString());
        //        //string destFilepdfdilicenciado = System.IO.Path.Combine(targetPath, Nombredocumentosolitopdf.ToString());
        //        string sourceFile = sourcePath + documentoPLANTILLA;
        //        string destFile = targetPath + documento;
        //        string destFilepdf = targetPathpdf + Nombredocumentosolitopdf;
        //        string destFilepdfdilicenciado = targetPath + Nombredocumentosolitopdf;

        //        System.IO.File.Copy(sourceFile, destFile, true);

        //        DataTable entidadseleccionada = ENTIDADESEXT.ENTIDADESEXTObtenerPORELNIT(NIT, "", 0);

        //        #endregion
                
        //        #endregion

        //        #region CONSULTADELFUNCIONARIOdestino

        //        DataTable DOCUMENTOSGESTIONDELDOCUMENTO = DOCUMENTOSGESTION.DOCUMENTOSGESTIONObtenerbyIDDOCUMENTO(lstDOCUMENTO[0].IDDOCUMENTO, 1,usuario, idusuario);
                
        //        List<DCFUNCIONARIOS> lstFUNCIONARIOSTEMPORAL = new List<DCFUNCIONARIOS>();
        //        DataTable DtFUNCIONARIOSTEMPORAL = new DataTable();
        //        DtFUNCIONARIOSTEMPORAL = FUNCIONARIOS.FUNCIONARIOSObtenerbyIDFUNCIONARIO(Convert.ToDecimal(DOCUMENTOSGESTIONDELDOCUMENTO.Rows[0]["IDUSUARIOASIGNO"]), usuario, idusuario);

        //        for (int i = 0; i < DtFUNCIONARIOSTEMPORAL.Rows.Count; i++)
        //        {
        //            lstFUNCIONARIOSTEMPORAL.Add
        //            (
        //                new DCFUNCIONARIOS
        //                (
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDFUNCIONARIO"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["NOMBRES"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["NOMBRES"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["APELLIDOS"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["APELLIDOS"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["LOGIN"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["LOGIN"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["PASS"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["PASS"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["PERFILES"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["PERFILES"]),
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDSUCURSAL"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["SUCURSAL"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["SUCURSAL"]),
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDCENTROCOSTO"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["CENTROCOSTO"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["CENTROCOSTO"]),
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDUNIDADADMINISTRATIVA"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["UNIDADADMINISTRATIVA"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["UNIDADADMINISTRATIVA"]),
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDOFICINAPRODUCTORA"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["OFICINAPRODUCTORA"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["OFICINAPRODUCTORA"]),
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDCARGO"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["CARGO"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["CARGO"]),
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDNIVEL"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["NIVEL"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["NIVEL"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FOTO"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FOTO"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["EMAIL"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["EMAIL"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["ESTADO"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["ESTADO"]),
        //                    (System.Decimal)(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDUSUARIO"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["USUARIO"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["USUARIO"]),
        //                    Convert.ToDateTime(DtFUNCIONARIOSTEMPORAL.Rows[i]["FECHAGRABO"].Equals(System.DBNull.Value) ? new DateTime(190, 1, 1) : DtFUNCIONARIOSTEMPORAL.Rows[i]["FECHAGRABO"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["NOMBRESAPELLIDOS"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["NOMBRESAPELLIDOS"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA"]),
        //                    0, String.Empty, true, String.Empty,
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMAP12"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMAP12"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMATOKEN"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMATOKEN"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["RUBRICA"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["RUBRICA"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA1"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA1"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA2"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA2"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA3"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMA3"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["TELETRABAJO"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["TELETRABAJO"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMAP12PASS"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMAP12PASS"]),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMATOKENPASS"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["FIRMATOKENPASS"]),
        //                    Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDFUNCIONARIOREMPLAZO"].Equals(System.DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["IDFUNCIONARIOREMPLAZO"]),
        //                    (Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDFUNCIONARIOREMPLAZO"].Equals(System.DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["IDFUNCIONARIOREMPLAZO"]) == 0 ?
        //                    new DCFUNCIONARIOS(false) :
        //                    new DCFUNCIONARIOS()
        //                    {
        //                        IDFUNCIONARIO = Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["IDFUNCIONARIOREMPLAZO"].Equals(DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["IDFUNCIONARIOREMPLAZO"]),
        //                        NOMBRES = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_NOMBRES"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_NOMBRES"]),
        //                        APELLIDOS = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_APELLIDOS"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_APELLIDOS"]),
        //                        NOMBRESAPELLIDOS = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_NOMBRESAPELLIDOS"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_NOMBRESAPELLIDOS"]),
        //                        LOGIN = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_LOGIN"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_LOGIN"]),
        //                        PERFILES = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_PERFILES"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_PERFILES"]),
        //                        IDSUCURSAL = Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDSUCURSAL"].Equals(DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDSUCURSAL"]),
        //                        SUCURSAL = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_SUCURSAL"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_SUCURSAL"]),
        //                        IDCENTROCOSTO = Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDCENTROCOSTO"].Equals(DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDCENTROCOSTO"]),
        //                        CENTROCOSTO = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_CENTROCOSTO"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_CENTROCOSTO"]),
        //                        IDUNIDADADMINISTRATIVA = Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDUNIDADADMINISTRATIVA"].Equals(DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDUNIDADADMINISTRATIVA"]),
        //                        UNIDADADMINISTRATIVA = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_UNIDADADMINISTRATIVA"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_UNIDADADMINISTRATIVA"]),
        //                        IDOFICINAPRODUCTORA = Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDOFICINAPRODUCTORA"].Equals(DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDOFICINAPRODUCTORA"]),
        //                        OFICINAPRODUCTORA = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_OFICINAPRODUCTORA"].Equals(DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_OFICINAPRODUCTORA"]),
        //                        IDCARGO = Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDCARGO"].Equals(DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDCARGO"]),
        //                        CARGO = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_CARGO"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_CARGO"]),
        //                        IDNIVEL = Convert.ToDecimal(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDNIVEL"].Equals(DBNull.Value) ? 0 : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_IDNIVEL"]),
        //                        NIVEL = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_NIVEL"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_NIVEL"]),
        //                        FOTO = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FOTO"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FOTO"]),
        //                        EMAIL = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_EMAIL"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_EMAIL"]),
        //                        FIRMA = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA"]),
        //                        FIRMAP12 = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMAP12"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMAP12"]),
        //                        FIRMATOKEN = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMATOKEN"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMATOKEN"]),
        //                        RUBRICA = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_RUBRICA"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_RUBRICA"]),
        //                        FIRMA1 = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA1"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA1"]),
        //                        FIRMA2 = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA2"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA2"]),
        //                        FIRMA3 = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA3"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMA3"]),
        //                        TELETRABAJO = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_TELETRABAJO"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_TELETRABAJO"]),
        //                        FIRMAP12PASS = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMAP12PASS"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMAP12PASS"]),
        //                        FIRMATOKENPASS = (String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMATOKENPASS"].Equals(DBNull.Value) ? String.Empty : DtFUNCIONARIOSTEMPORAL.Rows[i]["R_FIRMATOKENPASS"])
        //                    }),
        //                    (System.String)(DtFUNCIONARIOSTEMPORAL.Rows[i]["PASS2"].Equals(System.DBNull.Value) ? "" : DtFUNCIONARIOSTEMPORAL.Rows[i]["PASS2"])
        //                )
        //            );
        //        }

        //        #endregion

        //        #region CONSULTA DE INSUMOS PARA EL METODO

        //        DOCUMENTOESCRIBE DOCUMENTOESCIBESELECCIONADO = new DOCUMENTOESCRIBE();
        //        DOCUMENTOESCIBESELECCIONADO.FUNCIONARIOLOGIN = lstFUNCIONARIOSTEMPORAL[0];
        //        DOCUMENTOESCIBESELECCIONADO.DESTINATARIO = lstFUNCIONARIOSTEMPORAL[0].NOMBRESAPELLIDOS;
        //        DOCUMENTOESCIBESELECCIONADO.DESTINATARIOS = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.UNIDAD_DEST = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.OFICINA_DEST = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.CARGO_DEST = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.CIUDAD_DEST = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.DEPTO_DEST = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.FIRMANTE = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.UNIDAD_FIRM = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.OFICINA_FIRM = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.CARGO_FIRM = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.CIUDAD_FIRM = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.DEPTO_FIRM = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.OTROS_DATOS = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.FIRMANTEROTULO = String.Empty;
        //        DOCUMENTOESCIBESELECCIONADO.DESTINATARIOROTULO = String.Empty;

        //        DataTable ADJUNTOSELECCIONADO = ADJUNTOS.ADJUNTOSObtenerbyIDDOCUMENTO(lstDOCUMENTO[0].IDDOCUMENTO, usuario, idusuario);

        //        String NOMBRESOLITO = (ADJUNTOSELECCIONADO.Rows[0]["ARCHIVONOMBRE"]).ToString();
        //        NOMBRESOLITO = NOMBRESOLITO.Replace(".pdf", "");
        //        NOMBRESOLITO = NOMBRESOLITO.Replace(".docx", "");

        //        //String rutaApp = @AppDomain.CurrentDomain.BaseDirectory;
        //        //String rutadoc = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @".docx";
        //        //String rutanewdoc = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @"wm.docx";
        //        //String rutapdf = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @".pdf";
        //        //String rutapdfimagen = rutaApp + @"PDF\" + NOMBRESOLITO + @".pdf";
        //        //String rutanewpdf = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @"wm.pdf";
        //        //String rutaMarca = rutaApp + @"IMAGES\cancelled.jpg";

        //        EscribirDocumento(lstDOCUMENTO[0], DOCUMENTOESCIBESELECCIONADO, entidadseleccionada, sourceFile, destFile, destFilepdf, destFilepdfdilicenciado);

        //        #endregion

        //        #region METODO ANTIGUO

        //        //string fechanueva;

        //        //fechanueva = lstDOCUMENTO[0].FECHARADICO.Day.ToString() + "/" + lstDOCUMENTO[0].FECHARADICO.Month.ToString() + "/" + lstDOCUMENTO[0].FECHARADICO.Year.ToString();

        //        //String destino_file = String.Empty;

        //        //String routlocargado = String.Empty;

        //        //routlocargado = "Al contestar cite Radicado " + lstDOCUMENTO[0].RADICADO + " Id: " + lstDOCUMENTO[0].IDDOCUMENTO + " Folios: " + lstDOCUMENTO[0].NROFOLIOS + " Anexos: " + lstDOCUMENTO[0].ANEXONUMERO + "" + Environment.NewLine +
        //        //      "Fecha : " + fechanueva + " Dependencia: {5}" + Environment.NewLine +
        //        //      "Origen: {6}" + Environment.NewLine +
        //        //      "Destino: {7}" + Environment.NewLine +
        //        //      "Serie : {8} " + Environment.NewLine +
        //        //      "SubSerie : {9} Tipo Documental {10}";

        //        //switch (from)
        //        //{
        //        //    case "CREAR.PQR.DOC":


        //        //        destino_file = ConfigurationManager.AppSettings["RutaFormatosDocsPQRreemplazo"] + documento.ToString();

        //        //        using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(destino_file, true))
        //        //        {
        //        //            String docText = String.Empty;
        //        //            using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
        //        //            {
        //        //                docText = sr.ReadToEnd();
        //        //            }

        //        //            Regex regexText = null;

        //        //            #region Reemplazos

        //        //            regexText = new Regex("R4D1C4D0");
        //        //            docText = regexText.Replace(docText, routlocargado.ToString());

        //        //            regexText = new Regex("FECH4");
        //        //            docText = regexText.Replace(docText, fechanueva.ToString());

        //        //            regexText = new Regex("C3DUL4");
        //        //            docText = regexText.Replace(docText, entidadseleccionada.Rows[0]["NIT"].ToString());

        //        //            regexText = new Regex("T3L3FONO");
        //        //            docText = regexText.Replace(docText, entidadseleccionada.Rows[0]["TELEFONO"].ToString());

        //        //            regexText = new Regex("D1R3CC1ON");
        //        //            docText = regexText.Replace(docText, entidadseleccionada.Rows[0]["DIRECCION"].ToString());

        //        //            regexText = new Regex("3M4IL");
        //        //            docText = regexText.Replace(docText, entidadseleccionada.Rows[0]["EMAIL"].ToString());

        //        //            regexText = new Regex("FHIRWANT3");
        //        //            docText = regexText.Replace(docText, entidadseleccionada.Rows[0]["NOMBRES"].ToString());

        //        //            regexText = new Regex("P3T1C1ON");
        //        //            docText = regexText.Replace(docText, lstDOCUMENTO[0].DESCRIPCION);

        //        //            #endregion

        //        //            using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
        //        //            {
        //        //                sw.Write(docText);
        //        //            }
        //        //        }
        //        //        break;
        //        //    default:
        //        //        break;
        //        //}
        //        //generarelpdf(lstDOCUMENTO[0].IDDOCUMENTO, usuario, idusuario);
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    {
        //        String fic = @"c:\\tmp\\error_gen_docx.txt";
        //        String texto = ex.Message + " " + " " + ex.StackTrace + " " + ex.InnerException;

        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
        //        sw.WriteLine(texto);
        //        sw.Close();

        //        throw ex;
        //    }
        //}

        //private static void EscribirDocumento(DCDOCUMENTOS Doc, DOCUMENTOESCRIBE DocEscribe, DataTable entidadseleccionada, String rutadoc, String rutanewdoc, String rutanewpdf, String rutanewpdfdiligenciado)
        //{
        //    try
        //    {
        //        if (File.Exists(rutadoc))
        //        {
        //            #region Variables

        //            String rutaApp = @AppDomain.CurrentDomain.BaseDirectory;
        //            String rutaFirma = rutaApp + @"IMAGES\FIRMASMECANICAS\";
        //            String rutaRubrica = rutaApp + @"IMAGES\RUBRICAS\";

        //            String ROTULO = "{0}";
        //            String Rotulo = String.Empty;

        //            String formatofecha = DateTime.Now.Day.ToString() + " de " +
        //                Global.FirstLetterToUpper(Global.retornar_string_mes(Convert.ToInt32(DateTime.Now.Month.ToString()))) + " de " +
        //                DateTime.Now.Year.ToString();

        //            String fecharadico = Doc.FECHARADICO.ToString("dd-MMMM-yyyy hh:mm:ss");

        //            #endregion

        //            #region FORMATO ROTULO

        //            if (ConfigurationManager.AppSettings["FormatoRotuloCeroPapel"] == "0")
        //            {
        //                ROTULO = ConfigurationManager.AppSettings["RazonSocial"].ToUpper() + Environment.NewLine +
        //                 "Radicado  {0} Id: {1} Folios: {2} Anexos: {3}" + Environment.NewLine +
        //                 "Fecha : {4} Dependencia : {5}" + Environment.NewLine +
        //                 " Destino : {6} " + Environment.NewLine +
        //                 "Serie : {7}" + Environment.NewLine +
        //                 " SubSerie : {8}";
        //            }
        //            else if (ConfigurationManager.AppSettings["FormatoRotuloCeroPapel"] == "1")
        //            {
        //                ROTULO = ConfigurationManager.AppSettings["RazonSocial"].ToUpper() + Environment.NewLine +
        //                 "Radicado  {0} Id: {1} Folios: {2} Anexos: {3}" + Environment.NewLine +
        //                 "Fecha : {4} Dependencia : {5}" + Environment.NewLine +
        //                 " Destino : {6} " + Environment.NewLine +
        //                 "Serie : {7}" + Environment.NewLine +
        //                 " SubSerie : {8}";
        //            }
        //            else if (ConfigurationManager.AppSettings["FormatoRotuloCeroPapel"] == "2")
        //            {
        //                ROTULO = ConfigurationManager.AppSettings["RazonSocial"].ToUpper() + Environment.NewLine +
        //                 "Radicado  {0} Id: {1} Folios: {2} Anexos: {3}" + Environment.NewLine +
        //                 "Fecha : {4} Dependencia : {5}" + Environment.NewLine +
        //                 " Destino : {6} " + Environment.NewLine +
        //                 "Serie : {7}" + Environment.NewLine +
        //                 " SubSerie : {8}";
        //            }
        //            else if (ConfigurationManager.AppSettings["FormatoRotuloCeroPapel"] == "3")
        //            {
        //                ROTULO = ConfigurationManager.AppSettings["RazonSocial"].ToUpper() + Environment.NewLine +
        //                 "Radicado  {0} Id: {1} Folios: {2} Anexos: {3}" + Environment.NewLine +
        //                 "Fecha : {4} Dependencia : {5}" + Environment.NewLine +
        //                 " Destino : {6} " + Environment.NewLine +
        //                 "Serie : {7}" + Environment.NewLine +
        //                 " SubSerie : {8}";
        //            }
        //            else if (ConfigurationManager.AppSettings["FormatoRotuloCeroPapel"] == "4")
        //            {
        //                   ROTULO = ConfigurationManager.AppSettings["RazonSocial"].ToUpper() + Environment.NewLine +
        //                    "Radicado  {0} Id: {1} Folios: {2} Anexos: {3}" + Environment.NewLine +
        //                    "Fecha : {4} Dependencia : {5}" + Environment.NewLine +
        //                    " Destino : {6} " + Environment.NewLine +
        //                    "Serie : {7}" + Environment.NewLine +
        //                    " SubSerie : {8}";
        //            }
        //            else
        //            {
        //                ROTULO = "{0}";
        //            }

        //            #endregion

        //            #region FIRMAS

        //            var fr = DocEscribe.FUNCIONARIOLOGIN.FIRMA;
        //            var fr1 = DocEscribe.FUNCIONARIOLOGIN.FIRMA1;
        //            var fr2 = DocEscribe.FUNCIONARIOLOGIN.FIRMA2;
        //            var fr3 = DocEscribe.FUNCIONARIOLOGIN.FIRMA3;
        //            var ru = DocEscribe.FUNCIONARIOLOGIN.RUBRICA;

        //            #endregion

        //            //Copia el Archivo para modificarlo
        //            System.IO.File.Copy(rutadoc, rutanewdoc, true);
        //            //File.Copy(rutadoc, rutanewdoc, true);

        //            // Create a Wordprocessing document 
        //            using (WordprocessingDocument package = WordprocessingDocument.Open(rutanewdoc, true))
        //            {
        //                // Assign a reference to the existing document body
        //                Body body = package.MainDocumentPart.Document.Body;
        //                MainDocumentPart mainPart = package.MainDocumentPart;
        //                String contentStr = body.InnerText;
        //                String contentXml = body.InnerXml;

        //                #region REMPLAZO TEXTOS

        //                #region Superior
                        
        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("FECH4")))
        //                {
        //                    text.Text = text.Text.Replace("FECH4", formatofecha);
        //                }
                        
        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("")))
        //                {
        //                    text.Text = text.Text.Replace("", "*" + Doc.IDDOCUMENTO.ToString() + "*");
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("R4D1C4D0")))
        //                {
        //                    Rotulo = String.Format(ROTULO,
        //                        Doc.RADICADO,
        //                        Doc.IDDOCUMENTO,
        //                        Doc.NROFOLIOS,
        //                        Doc.ANEXONUMERO,
        //                        fecharadico,
        //                        Doc.OFICINAPRODUCTORA,
        //                        Doc.GESTORNOMBRESAPELLIDOS,
        //                        Doc.SERIE,
        //                        Doc.SUBSERIE);

        //                    text.Text = text.Text.Replace("R4D1C4D0", Rotulo);
        //                }

        //                #endregion

        //                #region Destinatario

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("NOMBRES_DESTINATARIO")))
        //                {
        //                    text.Text = text.Text.Replace("NOMBRES_DESTINATARIO", DocEscribe.DESTINATARIO);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("OFICINA_DESTINATARIO")))
        //                {
        //                    text.Text = text.Text.Replace("OFICINA_DESTINATARIO", DocEscribe.OFICINA_DEST);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("UNIDAD_DESTINATARIO")))
        //                {
        //                    text.Text = text.Text.Replace("UNIDAD_DESTINATARIO", DocEscribe.UNIDAD_DEST);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("CARGO_DESTINATARIO")))
        //                {
        //                    text.Text = text.Text.Replace("CARGO_DESTINATARIO", DocEscribe.CARGO_DEST);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("CIUDAD_DESTINATARIO")))
        //                {
        //                    text.Text = text.Text.Replace("CIUDAD_DESTINATARIO", DocEscribe.CIUDAD_DEST);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("DEPTO_DESTINATARIO")))
        //                {
        //                    text.Text = text.Text.Replace("DEPTO_DESTINATARIO", DocEscribe.DEPTO_DEST);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("O8t0s")))
        //                {
        //                    text.Text = text.Text.Replace("O8t0s", DocEscribe.OTROS_DATOS);
        //                }
        //                //-------------------------------

        //                string fechanueva;

        //                fechanueva = Doc.FECHARADICO.Day.ToString() + "/" + Doc.FECHARADICO.Month.ToString() + "/" + Doc.FECHARADICO.Year.ToString();


        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("FECH4")))
        //                {
        //                    text.Text = text.Text.Replace("FECH4", fechanueva.ToString());
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("C3DUL4")))
        //                {
        //                    text.Text = text.Text.Replace("C3DUL4", entidadseleccionada.Rows[0]["NIT"].ToString());
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("T3L3FONO")))
        //                {
        //                    text.Text = text.Text.Replace("T3L3FONO", entidadseleccionada.Rows[0]["TELEFONO"].ToString());
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("D1R3CC1ON")))
        //                {
        //                    text.Text = text.Text.Replace("D1R3CC1ON", entidadseleccionada.Rows[0]["DIRECCION"].ToString());
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("3M4IL")))
        //                {
        //                    text.Text = text.Text.Replace("3M4IL", entidadseleccionada.Rows[0]["CORREOELECTRONICO2"].ToString());
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("FHIRWANT3")))
        //                {
        //                    text.Text = text.Text.Replace("FHIRWANT3", entidadseleccionada.Rows[0]["NOMBRES"].ToString());
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("P3T1C1ON")))
        //                {
        //                    text.Text = text.Text.Replace("P3T1C1ON", Doc.DESCRIPCION);
        //                }
                        
        //                #endregion

        //                #region Firmante

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("NOMBRES_FIRMANTE")))
        //                {
        //                    text.Text = text.Text.Replace("NOMBRES_FIRMANTE", DocEscribe.FIRMANTE);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("OFICINA_FIRMANTE")))
        //                {
        //                    text.Text = text.Text.Replace("OFICINA_FIRMANTE", DocEscribe.OFICINA_FIRM);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("UNIDAD_FIRMANTE")))
        //                {
        //                    text.Text = text.Text.Replace("UNIDAD_FIRMANTE", DocEscribe.UNIDAD_FIRM);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("CARGO_FIRMANTE")))
        //                {
        //                    text.Text = text.Text.Replace("CARGO_FIRMANTE", DocEscribe.CARGO_FIRM);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("CIUDAD_FIRMANTE")))
        //                {
        //                    text.Text = text.Text.Replace("CIUDAD_FIRMANTE", DocEscribe.CIUDAD_FIRM);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("DEPTO_FIRMANTE")))
        //                {
        //                    text.Text = text.Text.Replace("DEPTO_FIRMANTE", DocEscribe.DEPTO_FIRM);
        //                }

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("NOMBRE_ENTIDAD")))
        //                {
        //                    text.Text = text.Text.Replace("NOMBRE_ENTIDAD", DocEscribe.FUNCIONARIOLOGIN.RAZONSOCIAL);
        //                }

        //                #endregion

        //                #region Texto_TRD

        //                if (!String.IsNullOrEmpty(Doc.UNIDADADMINISTRATIVA))
        //                {
        //                    String archivado = "Archivado en: " + Doc.UNIDADADMINISTRATIVA + " - " + Doc.OFICINAPRODUCTORA + " - " + Doc.SERIE + " - " + Doc.SUBSERIE;

        //                    foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("T4#3")))
        //                    {
        //                        text.Text = text.Text.Replace("T4#3", archivado);
        //                    }
        //                }

        //                #endregion

        //                #region Texto_HASH

        //                if (ConfigurationManager.AppSettings["CodigosQR"] == "SI")
        //                {
        //                    foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("#H4SH")))
        //                    {
        //                        text.Text = text.Text.Replace("#H4SH", "Hash:" + Doc.HUELLA);
        //                    }
        //                }

        //                #endregion

        //                #region Codigo_Barras

        //                foreach (Text text in body.Descendants<Text>().Where(t => t.Text.Contains("R3DkODE-39")))
        //                {
        //                    #region REGISTRAR FUENTE

        //                    PrivateFontCollection _myFonts = new PrivateFontCollection();
        //                    _myFonts.AddFontFile(rutaApp + @"FONTS\Code39.ttf");
        //                    System.Drawing.FontFamily family = _myFonts.Families[0];
        //                    System.Drawing.Font font = new System.Drawing.Font(family, 20);

        //                    #endregion                            

        //                    OpenXmlElement parent = text.Parent;

        //                    if (parent != null)
        //                    {
        //                        if (parent is Run)
        //                        {
        //                            ImagePart ip = mainPart.AddImagePart(ImagePartType.Png);
        //                            String imageRelationshipID = mainPart.CreateRelationshipToPart(ip);
        //                            using (Stream imgStream = ip.GetStream())
        //                            {
        //                                Stream stream = TextoAStream(Doc.IDDOCUMENTO.ToString(), font, ImageFormat.Jpeg);

        //                                System.Drawing.Bitmap b = new System.Drawing.Bitmap(stream);

        //                                b.Save(imgStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                            }

        //                            Drawing drawing = CrearDrawing(imageRelationshipID);

        //                            text.Parent.InsertAfter<Drawing>(drawing, text);

        //                            text.Remove();
        //                        }
        //                    }
        //                }

        //                #endregion

        //                #endregion

        //                // Close the handle explicitly.
        //                package.Close();
        //                package.Dispose();

        //                #region GUARDAR PDF

        //                SDC.Document docSDC = new SDC.Document();
        //                docSDC.LoadFromFile(rutanewdoc);
        //                docSDC.SaveToFile(rutanewpdf, SDC.FileFormat.PDF);
        //                docSDC.SaveToFile(rutanewpdfdiligenciado, SDC.FileFormat.PDF);

        //                #endregion
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string fic = @"c:\\tmp\\EscribirDocumentoOpenxml.txt";
        //        string texto = ex.Message + "EscribirDocumentoOpenxml " + ex.Source + " " + ex.StackTrace + " " + ex.InnerException + " ";
                
        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
        //        sw.WriteLine(texto);
        //        sw.Close();
        //        throw new Exception("Ha ocurrido un error al generar el(los) archivo(s)");
        //    }
        //}

        //private static Drawing CrearDrawing(String relationshipId)
        //{
        //    try
        //    {
        //        // Define the reference of the image.
        //        return new Drawing(
        //                 new DW.Inline(
        //                     new DW.Extent() { Cx = 990000L, Cy = 792000L },
        //                     new DW.EffectExtent()
        //                     {
        //                         LeftEdge = 0L,
        //                         TopEdge = 0L,
        //                         RightEdge = 0L,
        //                         BottomEdge = 0L
        //                     },
        //                     new DW.DocProperties()
        //                     {
        //                         Id = (UInt32Value)1U,
        //                         Name = "Picture 1"
        //                     },
        //                     new DW.NonVisualGraphicFrameDrawingProperties(
        //                         new A.GraphicFrameLocks() { NoChangeAspect = true }),
        //                     new A.Graphic(
        //                         new A.GraphicData(
        //                             new PIC.Picture(
        //                                 new PIC.NonVisualPictureProperties(
        //                                     new PIC.NonVisualDrawingProperties()
        //                                     {
        //                                         Id = (UInt32Value)0U,
        //                                         Name = "New Bitmap Image.jpg"
        //                                     },
        //                                     new PIC.NonVisualPictureDrawingProperties()),
        //                                 new PIC.BlipFill(
        //                                     new A.Blip(
        //                                         new A.BlipExtensionList(
        //                                             new A.BlipExtension()
        //                                             {
        //                                                 Uri =
        //                                                   "{28A0092B-C50C-407E-A947-70E740481C1C}"
        //                                             })
        //                                     )
        //                                     {
        //                                         Embed = relationshipId,
        //                                         CompressionState =
        //                                         A.BlipCompressionValues.Print
        //                                     },
        //                                     new A.Stretch(
        //                                         new A.FillRectangle())),
        //                                 new PIC.ShapeProperties(
        //                                     new A.Transform2D(
        //                                         new A.Offset() { X = 0L, Y = 0L },
        //                                         new A.Extents() { Cx = 990000L, Cy = 792000L }),
        //                                     new A.PresetGeometry(
        //                                         new A.AdjustValueList()
        //                                     )
        //                                     { Preset = A.ShapeTypeValues.Rectangle }))
        //                         )
        //                         { Uri = "http://schemas.openxmlformats.org/drawingml/2006/picture" })
        //                 )
        //                 {
        //                     DistanceFromTop = (UInt32Value)0U,
        //                     DistanceFromBottom = (UInt32Value)0U,
        //                     DistanceFromLeft = (UInt32Value)0U,
        //                     DistanceFromRight = (UInt32Value)0U,
        //                     EditId = "50D07946"
        //                 });
        //    }
        //    catch (Exception ex)
        //    {
        //        string fic = @"c:\\tmp\\CrearDrawing.txt";
        //        string texto = ex.Message + "CrearDrawing " + ex.Source + " " + ex.StackTrace + " " + ex.InnerException + " ";

        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
        //        sw.WriteLine(texto);
        //        sw.Close();
        //        throw new Exception("Ha ocurrido un error al generar el(los) archivo(s)");
        //    }
        //}

        //private static Stream TextoAStream(String text, System.Drawing.Font font, ImageFormat format)
        //{
        //    try
        //    {
        //        #region Image

        //        Image img = new Bitmap(1, 1);
        //        Graphics drawing = Graphics.FromImage(img);

        //        SizeF textSize = drawing.MeasureString(text, font);

        //        img.Dispose();
        //        drawing.Dispose();

        //        img = new Bitmap((int)textSize.Width, (int)textSize.Height);

        //        drawing = Graphics.FromImage(img);

        //        drawing.Clear(System.Drawing.Color.White);

        //        Brush textBrush = new SolidBrush(System.Drawing.Color.Black);

        //        drawing.DrawString(text, font, textBrush, 0, 0);

        //        drawing.Save();

        //        textBrush.Dispose();
        //        drawing.Dispose();

        //        #endregion

        //        #region Stream

        //        var ms = new MemoryStream();
        //        img.Save(ms, format);

        //        #endregion

        //        return ms;
        //    }
        //    catch (Exception ex)
        //    {
        //        string fic = @"c:\\tmp\\TextoAStream.txt";
        //        string texto = ex.Message + "TextoAStream " + ex.Source + " " + ex.StackTrace + " " + ex.InnerException + " ";

        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
        //        sw.WriteLine(texto);
        //        sw.Close();
        //        throw new Exception("Ha ocurrido un error al generar el(los) archivo(s)");
        //    }
        //}

        //#region METODO ANTIGUO

        //public static bool generarelpdf(Decimal IDDOCUMENTO, String USUARIO, Decimal IDUSUARIO)
        //{
        //    try
        //    {
        //        DataTable ADJUNTOSELECCIONADO = ADJUNTOS.ADJUNTOSObtenerbyIDDOCUMENTO(IDDOCUMENTO, USUARIO, IDUSUARIO);

        //        String NOMBRESOLITO = (ADJUNTOSELECCIONADO.Rows[0]["ARCHIVONOMBRE"]).ToString();
        //        NOMBRESOLITO = NOMBRESOLITO.Replace(".pdf", "");
        //        NOMBRESOLITO = NOMBRESOLITO.Replace(".docx", "");

        //        String rutaApp = @AppDomain.CurrentDomain.BaseDirectory;
        //        String rutadoc = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @".docx";
        //        String rutanewdoc = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @"wm.docx";
        //        String rutapdf = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @".pdf";
        //        String rutapdfimagen = rutaApp + @"PDF\" + NOMBRESOLITO + @".pdf";
        //        String rutanewpdf = rutaApp + @"PDF\DOC_DILIGENCIADO\" + NOMBRESOLITO + @"wm.pdf";
        //        String rutaMarca = rutaApp + @"IMAGES\cancelled.jpg";

        //        bool confirmacion = false;

        //        if (File.Exists(rutadoc))
        //        {
        //            //Marca de Agua .docx
        //            //Cargar Archivo
        //            SDC.Document document = new SDC.Document();
        //            document.LoadFromFile(rutadoc);

        //            //Guarda Nuevo con Marca
        //            document.SaveToFile(rutanewdoc, SDC.FileFormat.Docx);

        //            //Convertir en PDF con Marca
        //            SDC.Document docSDC = new SDC.Document();
        //            docSDC.LoadFromFile(rutanewdoc);
        //            ////Convert Word to PDF 
        //            //docSDC.SaveToFile(rutanewpdf, SDC.FileFormat.PDF);

        //            File.Delete(rutapdf);
        //            if (File.Exists(rutapdf)) File.Delete(rutapdf);

        //            File.Delete(rutapdfimagen);
        //            if (File.Exists(rutapdfimagen)) File.Delete(rutapdfimagen);

        //            //Convert Word to PDF 
        //            docSDC.SaveToFile(rutapdf, SDC.FileFormat.PDF);
        //            docSDC.SaveToFile(rutapdfimagen, SDC.FileFormat.PDF);

        //            confirmacion = true;
        //        }
        //        return confirmacion;
        //    }
        //    catch (Exception ex)
        //    {
        //        string fic = @"c:\\tmp\\PONERMARCADEAGUADOCUMENTO.txt";
        //        string texto = ex.Message + "PONERMARCADEAGUADOCUMENTO " + ex.Source + " " + ex.StackTrace + " " + ex.TargetSite;

        //        System.IO.StreamWriter sw = new System.IO.StreamWriter(fic);
        //        sw.WriteLine(texto);
        //        sw.Close();

        //        return false;
        //    }
        //}

        //#endregion

        //#endregion
#endregion
    }
}
