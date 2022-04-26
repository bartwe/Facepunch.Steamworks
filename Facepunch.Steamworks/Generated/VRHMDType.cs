namespace Steamworks;

enum VRHMDType {
    MDType_None = -1,
    MDType_Unknown = 0,
    MDType_HTC_Dev = 1,
    MDType_HTC_VivePre = 2,
    MDType_HTC_Vive = 3,
    MDType_HTC_VivePro = 4,
    MDType_HTC_ViveCosmos = 5,
    MDType_HTC_Unknown = 20,
    MDType_Oculus_DK1 = 21,
    MDType_Oculus_DK2 = 22,
    MDType_Oculus_Rift = 23,
    MDType_Oculus_RiftS = 24,
    MDType_Oculus_Quest = 25,
    MDType_Oculus_Unknown = 40,
    MDType_Acer_Unknown = 50,
    MDType_Acer_WindowsMR = 51,
    MDType_Dell_Unknown = 60,
    MDType_Dell_Visor = 61,
    MDType_Lenovo_Unknown = 70,
    MDType_Lenovo_Explorer = 71,
    MDType_HP_Unknown = 80,
    MDType_HP_WindowsMR = 81,
    MDType_HP_Reverb = 82,
    MDType_HP_ReverbG2 = 1463,
    MDType_Samsung_Unknown = 90,
    MDType_Samsung_Odyssey = 91,
    MDType_Unannounced_Unknown = 100,
    MDType_Unannounced_WindowsMR = 101,
    MDType_vridge = 110,
    MDType_Huawei_Unknown = 120,
    MDType_Huawei_VR2 = 121,
    MDType_Huawei_EndOfRange = 129,
    mdType_Valve_Unknown = 130,
    mdType_Valve_Index = 131,
}