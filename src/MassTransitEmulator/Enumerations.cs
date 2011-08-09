using System;

namespace MassTransitEmulator
{
    public enum MessageType
    {
        Acknowledgment = 1,
        Normal = 2,
        Report = 3,
    } 

      [Flags]
  [Serializable]
  public enum MessageQueuePermissionAccess
  {
    None,
    Browse = 2,
    Send = 6,
    Peek = 10,
    Receive = 26,
    Administer = 62,
  }

      public enum MessageQueueResponseCode
      {
          [StringDescription("OK",0)]
          OK = 0,
          [StringDescription("Base", -1072824320)]
          Base = -1072824320,
          [StringDescription("Generic",-1072824319)]
          Generic = -1072824319,
          [StringDescription("Property",-1072824318)]
          Property = -1072824318,
          [StringDescription("QueueNotFound",-1072824317)]
          QueueNotFound = -1072824317,
          [StringDescription("QueueExists",-1072824315)]
          QueueExists = -1072824315,
          [StringDescription("InvalidParameter",-1072824314)]
          InvalidParameter = -1072824314,
          [StringDescription("InvalidHandle",-1072824313)]
          InvalidHandle = -1072824313,
          [StringDescription("OperationCanceled",-1072824312)]
          OperationCanceled = -1072824312,
          [StringDescription("SharingViolation",-1072824311)]
          SharingViolation = -1072824311,
          [StringDescription("ServiceNotAvailable",-1072824309)]
          ServiceNotAvailable = -1072824309,
          [StringDescription("MachineNotFound",-1072824307)]
          MachineNotFound = -1072824307,
          [StringDescription("IllegalSort",-1072824304)]
          IllegalSort = -1072824304,
          [StringDescription("IllegalUser",-1072824303)]
          IllegalUser = -1072824303,
          [StringDescription("NoDs",-1072824301)]
          NoDs = -1072824301,
          [StringDescription("IllegalQueuePathName",-1072824300)]
          IllegalQueuePathName = -1072824300,
          [StringDescription("IllegalPropertyValue",-1072824296)]
          IllegalPropertyValue = -1072824296,
          [StringDescription("IllegalPropertyVt",-1072824295)]
          IllegalPropertyVt = -1072824295,
          [StringDescription("BufferOverflow",-1072824294)]
          BufferOverflow = -1072824294,
          [StringDescription("IOTimeout",-1072824293)]
          IOTimeout = -1072824293,
          [StringDescription("IllegalCursorAction",-1072824292)]
          IllegalCursorAction = -1072824292,
          [StringDescription("MessageAlreadyReceived",-1072824291)]
          MessageAlreadyReceived = -1072824291,
          [StringDescription("IllegalFormatName",-1072824290)]
          IllegalFormatName = -1072824290,
          [StringDescription("FormatNameBufferTooSmall",-1072824289)]
          FormatNameBufferTooSmall = -1072824289,
          [StringDescription("UnsupportedFormatNameOperation",-1072824288)]
          UnsupportedFormatNameOperation = -1072824288,
          [StringDescription("IllegalSecurityDescriptor",-1072824287)]
          IllegalSecurityDescriptor = -1072824287,
          [StringDescription("SenderIdBufferTooSmall",-1072824286)]
          SenderIdBufferTooSmall = -1072824286,
          [StringDescription("SecurityDescriptorBufferTooSmall",-1072824285)]
          SecurityDescriptorBufferTooSmall = -1072824285,
          [StringDescription("CannotImpersonateClient",-1072824284)]
          CannotImpersonateClient = -1072824284,
          [StringDescription("AccessDenied",-1072824283)]
          AccessDenied = -1072824283,
          [StringDescription("PrivilegeNotHeld",-1072824282)]
          PrivilegeNotHeld = -1072824282,
          [StringDescription("InsufficientResources",-1072824281)]
          InsufficientResources = -1072824281,
          [StringDescription("UserBufferTooSmall",-1072824280)]
          UserBufferTooSmall = -1072824280,
          [StringDescription("MessageStorageFailed",-1072824278)]
          MessageStorageFailed = -1072824278,
          [StringDescription("SenderCertificateBufferTooSmall",-1072824277)]
          SenderCertificateBufferTooSmall = -1072824277,
          [StringDescription("InvalidCertificate",-1072824276)]
          InvalidCertificate = -1072824276,
          [StringDescription("CorruptedInternalCertificate",-1072824275)]
          CorruptedInternalCertificate = -1072824275,
          [StringDescription("NoInternalUserCertificate",-1072824273)]
          NoInternalUserCertificate = -1072824273,
          [StringDescription("CorruptedSecurityData",-1072824272)]
          CorruptedSecurityData = -1072824272,
          [StringDescription("CorruptedPersonalCertStore", -1072824271)]
          CorruptedPersonalCertStore = -1072824271,
          [StringDescription("ComputerDoesNotSupportEncryption", -1072824269)]
          ComputerDoesNotSupportEncryption = -1072824269,
          [StringDescription("BadSecurityContext",-1072824267)]
          BadSecurityContext = -1072824267,
          [StringDescription("CouldNotGetUserSid",-1072824266)]
          CouldNotGetUserSid = -1072824266,
          [StringDescription("CouldNotGetAccountInfo",-1072824265)]
          CouldNotGetAccountInfo = -1072824265,
          [StringDescription("IllegalCriteriaColumns",-1072824264)]
          IllegalCriteriaColumns = -1072824264,
          [StringDescription("IllegalPropertyId",-1072824263)]
          IllegalPropertyId = -1072824263,
          [StringDescription("IllegalRelation",-1072824262)]
          IllegalRelation = -1072824262,
          [StringDescription("IllegalPropertySize",-1072824261)]
          IllegalPropertySize = -1072824261,
          [StringDescription("IllegalRestrictionPropertyId",-1072824260)]
          IllegalRestrictionPropertyId = -1072824260,
          [StringDescription("IllegalQueueProperties",-1072824259)]
          IllegalQueueProperties = -1072824259,
          [StringDescription("PropertyNotAllowed",-1072824258)]
          PropertyNotAllowed = -1072824258,
          [StringDescription("InsufficientProperties",-1072824257)]
          InsufficientProperties = -1072824257,
          [StringDescription("MachineExists",-1072824256)]
          MachineExists = -1072824256,
          [StringDescription("IllegalMessageProperties",-1072824255)]
          IllegalMessageProperties = -1072824255,
          [StringDescription("DsIsFull",-1072824254)]
          DsIsFull = -1072824254,
          [StringDescription("DsError",-1072824253)]
          DsError = -1072824253,
          [StringDescription("InvalidOwner",-1072824252)]
          InvalidOwner = -1072824252,
          [StringDescription("UnsupportedAccessMode",-1072824251)]
          UnsupportedAccessMode = -1072824251,
          [StringDescription("ResultBufferTooSmall",-1072824250)]
          ResultBufferTooSmall = -1072824250,
          [StringDescription("DeleteConnectedNetworkInUse",-1072824248)]
          DeleteConnectedNetworkInUse = -1072824248,
          [StringDescription("NoResponseFromObjectServer",-1072824247)]
          NoResponseFromObjectServer = -1072824247,
          [StringDescription("ObjectServerNotAvailable",-1072824246)]
          ObjectServerNotAvailable = -1072824246,
          [StringDescription("QueueNotAvailable",-1072824245)]
          QueueNotAvailable = -1072824245,
          [StringDescription("DtcConnect",-1072824244)]
          DtcConnect = -1072824244,
          [StringDescription("TransactionImport",-1072824242)]
          TransactionImport = -1072824242,
          [StringDescription("TransactionUsage",-1072824240)]
          TransactionUsage = -1072824240,
          [StringDescription("TransactionSequence",-1072824239)]
          TransactionSequence = -1072824239,
          [StringDescription("MissingConnectorType",-1072824235)]
          MissingConnectorType = -1072824235,
          [StringDescription("StaleHandle",-1072824234)]
          StaleHandle = -1072824234,
          [StringDescription("TransactionEnlist",-1072824232)]
          TransactionEnlist = -1072824232,
          [StringDescription("QueueDeleted",-1072824230)]
          QueueDeleted = -1072824230,
          [StringDescription("IllegalContext",-1072824229)]
          IllegalContext = -1072824229,
          [StringDescription("IllegalSortPropertyId",-1072824228)]
          IllegalSortPropertyId = -1072824228,
          [StringDescription("LabelBufferTooSmall",-1072824226)]
          LabelBufferTooSmall = -1072824226,
          [StringDescription("MqisServerEmpty",-1072824225)]
          MqisServerEmpty = -1072824225,
          [StringDescription("MqisReadOnlyMode",-1072824224)]
          MqisReadOnlyMode = -1072824224,
          [StringDescription("SymmetricKeyBufferTooSmall",-1072824223)]
          SymmetricKeyBufferTooSmall = -1072824223,
          [StringDescription("SignatureBufferTooSmall",-1072824222)]
          SignatureBufferTooSmall = -1072824222,
          [StringDescription("ProviderNameBufferTooSmall",-1072824221)]
          ProviderNameBufferTooSmall = -1072824221,
          [StringDescription("IllegalOperation",-1072824220)]
          IllegalOperation = -1072824220,
          [StringDescription("WriteNotAllowed",-1072824219)]
          WriteNotAllowed = -1072824219,
          [StringDescription("WksCantServeClient",-1072824218)]
          WksCantServeClient = -1072824218,
          [StringDescription("DependentClientLicenseOverflow",-1072824217)]
          DependentClientLicenseOverflow = -1072824217,
          [StringDescription("CorruptedQueueWasDeleted",-1072824216)]
          CorruptedQueueWasDeleted = -1072824216,
          [StringDescription("RemoteMachineNotAvailable",-1072824215)]
          RemoteMachineNotAvailable = -1072824215,
          [StringDescription("UnsupportedOperation",-1072824214)]
          UnsupportedOperation = -1072824214,
          [StringDescription("EncryptionProviderNotSupported",-1072824213)]
          EncryptionProviderNotSupported = -1072824213,
          [StringDescription("CannotSetCryptographicSecurityDescriptor",-1072824212)]
          CannotSetCryptographicSecurityDescriptor = -1072824212,
          [StringDescription("CertificateNotProvided",-1072824211)]
          CertificateNotProvided = -1072824211,
          [StringDescription("QDnsPropertyNotSupported",-1072824210)]
          QDnsPropertyNotSupported = -1072824210,
          [StringDescription("CannotCreateCertificateStore",-1072824209)]
          CannotCreateCertificateStore = -1072824209,
          [StringDescription("CannotOpenCertificateStore",-1072824208)]
          CannotOpenCertificateStore = -1072824208,
          [StringDescription("IllegalEnterpriseOperation",-1072824207)]
          IllegalEnterpriseOperation = -1072824207,
          [StringDescription("CannotGrantAddGuid",-1072824206)]
          CannotGrantAddGuid = -1072824206,
          [StringDescription("CannotLoadMsmqOcm",-1072824205)]
          CannotLoadMsmqOcm = -1072824205,
          [StringDescription("NoEntryPointMsmqOcm",-1072824204)]
          NoEntryPointMsmqOcm = -1072824204,
          [StringDescription("NoMsmqServersOnDc",-1072824203)]
          NoMsmqServersOnDc = -1072824203,
          [StringDescription("CannotJoinDomain",-1072824202)]
          CannotJoinDomain = -1072824202,
          [StringDescription("CannotCreateOnGlobalCatalog",-1072824201)]
          CannotCreateOnGlobalCatalog = -1072824201,
          [StringDescription("GuidNotMatching",-1072824200)]
          GuidNotMatching = -1072824200,
          [StringDescription("PublicKeyNotFound",-1072824199)]
          PublicKeyNotFound = -1072824199,
          [StringDescription("PublicKeyDoesNotExist",-1072824198)]
          PublicKeyDoesNotExist = -1072824198,
          [StringDescription("IllegalPrivateProperties",-1072824197)]
          IllegalPrivateProperties = -1072824197,
          [StringDescription("NoGlobalCatalogInDomain",-1072824196)]
          NoGlobalCatalogInDomain = -1072824196,
          [StringDescription("NoMsmqServersOnGlobalCatalog",-1072824195)]
          NoMsmqServersOnGlobalCatalog = -1072824195,
          [StringDescription("CannotGetDistinguishedName",-1072824194)]
          CannotGetDistinguishedName = -1072824194,
          [StringDescription("CannotHashDataEx",-1072824193)]
          CannotHashDataEx = -1072824193,
          [StringDescription("CannotSignDataEx",-1072824192)]
          CannotSignDataEx = -1072824192,
          [StringDescription("CannotCreateHashEx",-1072824191)]
          CannotCreateHashEx = -1072824191,
          [StringDescription("FailVerifySignatureEx",-1072824190)]
          FailVerifySignatureEx = -1072824190,
          [StringDescription("MessageNotFound",-1072824184)]
          MessageNotFound = -1072824184,
          [StringDescription("InformationProperty",1074659329)]
          InformationProperty = 1074659329,  //&H400E0001
          [StringDescription("IllegalProperty",1074659330)]
          IllegalProperty = 1074659330,  //&H400E0002
          [StringDescription("PropertyIgnored",1074659331)]
          PropertyIgnored = 1074659331,  //&H400E0003
          [StringDescription("UnsupportedProperty",1074659332)]
          UnsupportedProperty = 1074659332,  //&H400E0004
          [StringDescription("DuplicateProperty",1074659333)]
          DuplicateProperty = 1074659333,  //&H400E0005
          [StringDescription("OperationPending",1074659334)]
          OperationPending = 1074659334,  //&H400E0006
          [StringDescription("FormatnameBufferTooSmall",1074659337)]
          FormatnameBufferTooSmall = 1074659337,  //&H400E0009
          [StringDescription("InternalUserCertExist",1074659338)]
          InternalUserCertExist = 1074659338,  //&H400E000A
          [StringDescription("OwnerInformationIgnored",1074659339)]
          OwnerInformationIgnored = 1074659339 //&H400E000B
      }

    public class StringDescriptionAttribute : Attribute
    {
        public string Description { get; private set; }
        public int Value { get; private set; }

        public StringDescriptionAttribute(string description, int val)
        {
            Description = description;
            Value = val;
        }
    }
}