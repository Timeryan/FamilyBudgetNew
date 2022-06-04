using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;

namespace FamilyBudgetContext.Contracts.Shared.Contracts.EnumExtensions;

public static class UserColorExtension
{
    public static string GetCodeByColor(this UserColorEnum color)
    {
        return color switch
        {
            UserColorEnum.Blue => "4280391411",
            UserColorEnum.Yellow => "4294961979",
            UserColorEnum.Green => "4283215696",
            UserColorEnum.Purple => "4288423856",
            UserColorEnum.DeepOrange => "4294924066",
            UserColorEnum.DeepPurpleAccent => "4286336511",
            UserColorEnum.Orange => "4294940672",
            UserColorEnum.Red => "4294198070",
            UserColorEnum.LightBlueAccent => "4282434815",
            UserColorEnum.RedAccent => "4294922834",
            UserColorEnum.LightGreenAccent => "4289920857",
            UserColorEnum.Grey => "4288585374",
            UserColorEnum.Teal => "4278228616",
            _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
        };
    }
    
    public static UserColorEnum GetColorByCode(this string code)
    {
        return code switch
        {
            "4280391411" => UserColorEnum.Blue, 
            "4294961979" => UserColorEnum.Yellow,
            "4283215696" => UserColorEnum.Green,
            "4288423856" => UserColorEnum.Purple,
            "4294924066" => UserColorEnum.DeepOrange,
            "4286336511" => UserColorEnum.DeepPurpleAccent,
            "4294940672" => UserColorEnum.Orange,
            "4294198070" => UserColorEnum.Red,
            "4282434815" => UserColorEnum.LightBlueAccent,
            "4294922834" => UserColorEnum.RedAccent,
            "4289920857" => UserColorEnum.LightGreenAccent,
            "4288585374" => UserColorEnum.Grey,
            "4278228616" => UserColorEnum.Teal,
            _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
        };
    }
}