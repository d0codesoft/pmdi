using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace pmdi.Model
{

    /// <summary>
    /// Represents base nopCommerce model
    /// </summary>
    public partial class BasePIModel
    {
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public BasePIModel()
        {
            CustomProperties = new Dictionary<string, object>();
            PostInitialize();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Perform additional actions for binding the model
        /// </summary>
        /// <param name="bindingContext">Model binding context</param>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom model binding</remarks>
        public virtual void BindModel(ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Perform additional actions for the model initialization
        /// </summary>
        /// <remarks>Developers can override this method in custom partial classes in order to add some custom initialization code to constructors</remarks>
        protected virtual void PostInitialize()
        {
        }

        #endregion

        #region Properties

        ////MVC is suppressing further validation if the IFormCollection is passed to a controller method. That's why we add it to the model
        //[XmlIgnore]
        //public IFormCollection Form { get; set; }

        /// <summary>
        /// Gets or sets property to store any custom values for models 
        /// </summary>
        [XmlIgnore]
        [NotMapped]
        public Dictionary<string, object> CustomProperties { get; set; }

        #endregion
    }

    //поддерживаемые языки
    public enum LangSupport
    {
        en = 0,
        ru = 1,
        tr = 2
    }

    //тип пользователя
    public enum UserType
    {
        patient = 0,
        dector
    }

    //пользователи системы
    public class Patients : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid IdUsers { get; set; }

        [StringLength(100)]
        [Required] // Data annotations needed to configure as required
        public string FirstName { get; set; }

        [StringLength(100)]
        [Required]
        public string LastName { get; set; } // Data annotations needed to configure as required

        [StringLength(100)]
        public string MiddleName { get; set; } // Optional by convention

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public byte[] PhotoPatient { get; set; }
    }

    //характеиристика дозировки
    //объем, вес, и пр.
    public enum TypeDasage
    {
        volume = 0,
        weingth
    }

    //Данные еденицы измерения дозировки лекарств
    public class UnitDosage : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(200)]
        public string Name_en { get; set; }

        [StringLength(200)]
        public string Name_ru { get; set; }

        [StringLength(200)]
        public string Name_tr { get; set; }

        public TypeDasage TypeDasage { get; set; }
    }

    //Дозировки лекарств
    public class ReferenceDrugs : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [StringLength(200)]
        public string Name_en { get; set; }
        [StringLength(200)]
        public string Name_ru { get; set; }
        [StringLength(200)]
        public string Name_tr { get; set; }
        [ForeignKey("UnitDosageID")]
        public UnitDosage UnitDosage { get; set; }
        public Guid UnitDosageID { get; set; }
        [Column(TypeName = "decimal(15,4)")]
        public Decimal Dosage { get; set; }
    }

    //синоним наименование лекарств
    public class DrugsSynonym : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("DrugsId")]
        public ReferenceDrugs Drugs { get; set; }
        [Required]
        public Guid DrugsId { get; set; }
        public LangSupport LangSybonym { get; set; }

        [StringLength(200)]
        public string NameSynonym { get; set; }
    }

    //График приема лексаств пациента
    public class PatientMedicine : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid IdUsers { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }

        [Display(Name = "Period reseving")]
        [DataType(DataType.Date)]
        public DateTimeOffset? PeriodReseving { get; set; }

        [Display(Name = "Begin reception")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BeginReception { get; set; }

        [Display(Name = "End reception")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndReception { get; set; }
        [ForeignKey("DrugsID")]
        public ReferenceDrugs Drugs { get; set; }
        public Guid DrugsID { get; set; }
        [ForeignKey("UnitDosageID")]
        public UnitDosage UnitDosage { get; set; }
        public Guid UnitDosageID { get; set; }
        public Decimal Dosage { get; set; }
    }

    //Справочник групп показателей измерений анализов (анализы крови, анализы мочи, прочие анализы)
    public class ReferenseTypeMeasuring : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name_en { get; set; }
        public string Name_ru { get; set; }
        public string Name_tr { get; set; }

        [ForeignKey("ParentId")]
        public ReferenseTypeMeasuring Parent { get; set; }
        public Guid? ParentId { get; set; }
        public ICollection<ReferenseTypeMeasuring> ChildItems { get; } = new List<ReferenseTypeMeasuring>();
    }

    //Справочник показателей измерений анализов
    public class ReferenсeMeasuring : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [ForeignKey("TypeMeasuringID")]
        public ReferenseTypeMeasuring TypeMeasuring { get; set; }
        public Guid TypeMeasuringID { get; set; }

        public string Name_en { get; set; }
        public string Name_ru { get; set; }
        public string Name_tr { get; set; }
    }

    //синоним наименование измерений анализов
    public class MeasuringSynonym : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("MeasuringId")]
        public ReferenсeMeasuring Measuring { get; set; }
        [Required]
        public Guid MeasuringId { get; set; }
        public LangSupport LangSynonym { get; set; }
        public string NameSynonym { get; set; }
    }

    //справчник соотношений измерений
    public class ReferenseRelationshipMeasuring : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("MeasuringFirstId")]
        public ReferenсeMeasuring MeasuringFirst { get; set; }
        [Required]
        public Guid MeasuringFirstId { get; set; }
        [ForeignKey("MeasuringSecondId")]
        public ReferenсeMeasuring MeasuringSecond { get; set; }
        [Required]
        public Guid MeasuringSecondId { get; set; }
        public Decimal CofficientRelationship { get; set; }
    }

    public enum TypeUnitAnalyse
    {
        symple = 0,
        relationship = 1
    }

    //Справочник данных наименований единиц изменея
    //анализов
    public class ReferenceUnitAnalyse : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        public TypeUnitAnalyse TypeUnitAnalyse { get; set; }
        [ForeignKey("MeasuringDenominatorId")]
        public ReferenсeMeasuring MeasuringDenominator { get; set; }
        [Required]
        public Guid MeasuringDenominatorId { get; set; }
        [ForeignKey("MeasuringNumeratorId")]
        public ReferenсeMeasuring MeasuringNumerator { get; set; }
        [Required]
        public Guid MeasuringNumeratorId { get; set; }
    }

    public class TypeAnalysis : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        public bool IsGroup { get; set; }
        public string Name_en { get; set; }
        public string Name_ru { get; set; }
        public string Name_tr { get; set; }
        public bool IsMark { get; set; }

        [ForeignKey("ParentId")]
        public TypeAnalysis Parent { get; set; }
        public Guid? ParentId { get; set; }
        public ICollection<TypeAnalysis> ChildItems { get; } = new List<TypeAnalysis>();
    }

    //Справочник самих анализов
    public class ReferenceAnalysis : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("BaseUnitAnalyseId")]
        public ReferenceUnitAnalyse BaseUnitAnalyse { get; set; }
        [Required]
        public Guid BaseUnitAnalyseId { get; set; }

        [ForeignKey("TypeAnalysisId")]
        public TypeAnalysis TypeAnalysis { get; set; }
        [Required]
        public Guid TypeAnalysisId { get; set; }

        public string Name_en { get; set; }
        public string Name_ru { get; set; }
        public string Name_tr { get; set; }
    }

    public class ReferenceLabalatory : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Descr { get; set; }
        public string RefDownloadResult { get; set; }
        public string Site { get; set; }
    }

    //Анализы пациента
    public class PatientAnalysis : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public DateTime DateAnalysis { get; set; }
        [ForeignKey("AnalysisId")]
        public ReferenceAnalysis Analysis { get; set; }
        [Required]
        public Guid AnalysisId { get; set; }
        public Decimal ValueAnalysis { get; set; }
        [ForeignKey("MeasuringId")]
        public ReferenсeMeasuring Measuring { get; set; }
        [Required]
        public Guid MeasuringId { get; set; }
        [ForeignKey("LabalatoryId")]
        public ReferenceLabalatory Labalatory { get; set; }
        public Guid LabalatoryId { get; set; }
    }

    //public enum StateTaskDownloadAnalysis
    //{
    //    stWait = 0,
    //    stWork = 1,
    //    stFinish = 2,
    //    stError = 3
    //}

    //public class HistoryTaskWaitAnalysis
    //{
    //    [Key]
    //    public Guid idTask { get; set; }
    //    public Guid UserId { get; set; }
    //    public DateTime beginDate { get; set; }
    //    public DateTime endDate { get; set; }
    //    public ReferenceLabalatory labolatory { get; set; }
    //    public string AccessToken { get; set; }
    //    public StateTaskownloadAnalysis stateTaskAnalysis { get; set; }
    //    public string stateTack_ru { get; set; }
    //    public string stateTack_en { get; set; }
    //    public string stateTack_tr { get; set; }
    //}

    //public class TaskWaitAnalysis
    //{
    //    [Key]
    //    public Guid idTask { get; set; }
    //    public Users iduser { get; set; }
    //    public DateTime beginDate { get; set; }
    //    public ReferenceLabalatory labolatory { get; set; }
    //    public string AccessToken { get; set; }
    //    public StateTaskownloadAnalysis stateTaskAnalysis { get; set; }
    //    public string stateTack_ru { get; set; }
    //    public string stateTack_en { get; set; }
    //    public string stateTack_tr { get; set; }
    //}

    public class DocumentsPatient : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public DateTime DateUpload { get; set; }
        public string Name { get; set; }
        public string Descr_en { get; set; }
        public string Descr_ru { get; set; }
        public string Descr_tr { get; set; }
        public bool IsOSR { get; set; }
        public byte[] DataDoc { get; set; }
    }

    public enum StateTaskOCR
    {
        stWait = 0,
        stWork = 1,
        stFinish = 2,
        stError = 3
    }

    public class HistiryTackOCR : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("DocPatientId")]
        public DocumentsPatient DocPatient { get; set; }
        public Guid DocPatientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public StateTaskOCR State { get; set; }
        public string DescrState_en { get; set; }
        public string DescrState_ru { get; set; }
        public string DescrState_tr { get; set; }
    }

    public class TackOCR : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("DocPatientId")]
        public DocumentsPatient DocPatient { get; set; }
        public Guid DocPatientId { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsWork { get; set; }
    }

    public class VitalSignsPatients : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public uint BludPressureUpper { get; set; }
        public uint BludPressureLower { get; set; }
        public uint Pulse { get; set; }
        [Column(TypeName = "decimal(5,1)")]
        public Decimal Temp { get; set; }
    }

    public class DiagnosisPatientsDoc : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public byte[] Document { get; set; }
    }

    public class ReferenсeDoctors : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public string Name_en { get; set; }
        public string Name_ru { get; set; }
        public string Name_tr { get; set; }
    }


    public class DiagnosisPatients : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }

        public string InfoDiagnosis { get; set; }
        public ICollection<DiagnosisPatientsDoc> Documents { get; set; }
        [ForeignKey("DoctorId")] 
        public ReferenсeDoctors Doctor { get; set; }
        public Guid? DoctorId { get; set; }
    }


    public class MedicalTreatment : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public DateTime DateAppointment { get; set; }
        [ForeignKey("DoctorId")]
        public ReferenсeDoctors Doctor { get; set; }
        public Guid? DoctorId { get; set; }
        public string InfoTreatment { get; set; }
    }

    public class TokenSharedViewPatient : BasePIModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public Guid Tsi { get; set; }
        [ForeignKey("PatientId")]
        public Patients Patient { get; set; }
        [Required]
        public Guid PatientId { get; set; }
        public DateTime DateExpire { get; set; }
        public bool DeleteAfterView { get; set; } 
    }
}
