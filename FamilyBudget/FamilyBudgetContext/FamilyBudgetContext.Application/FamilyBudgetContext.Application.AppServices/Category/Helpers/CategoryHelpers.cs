using System.Collections.Generic;
using FamilyBudgetContext.Contracts.Shared.Contracts.Enums;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Category.Helpers;

public static class CategoryHelpers
{
    public static readonly List<CategoryEntity> DefaultCategories = new()
    {
        new()
        {
            Name = "Досуг",
            IconCode = "59408",
            IconColor = "4280391411",
            BlockLocation = 1,
            PositionLocation = 1,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new()
        {
            Name = "Еда",
            IconCode = "61685",
            IconColor = "4294961979",
            BlockLocation = 1,
            PositionLocation = 2,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new()
        {
            Name = "Жилье",
            IconCode = "59413",
            IconColor = "4283215696",
            BlockLocation = 1,
            PositionLocation = 3,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new()
        {
            Name = "Гигиена",
            IconCode = "59409",
            IconColor = "4288423856",
            BlockLocation = 1,
            PositionLocation = 4,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Питомцы",
            IconCode = "63166",
            IconColor = "4294924066",
            BlockLocation = 2,
            PositionLocation = 1,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Одежда",
            IconCode = "59411",
            IconColor = "4286336511",
            BlockLocation = 2,
            PositionLocation = 2,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Транспорт",
            IconCode = "59398",
            IconColor = "4294940672",
            BlockLocation = 3,
            PositionLocation = 1,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Здоровье",
            IconCode = "59410",
            IconColor = "4294198070",
            BlockLocation = 3,
            PositionLocation = 2,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Подписки",
            IconCode = "59412",
            IconColor = "4282434815",
            BlockLocation = 4,
            PositionLocation = 1,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Подарки",
            IconCode = "61547",
            IconColor = "4294922834",
            BlockLocation = 4,
            PositionLocation = 2,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Хобби",
            IconCode = "59418",
            IconColor = "4289920857",
            BlockLocation = 4,
            PositionLocation = 3,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Другое",
            IconCode = "59414",
            IconColor = "4288585374",
            BlockLocation = 4,
            PositionLocation = 4,
            MoneyFlowType = MoneyFlowTypeEnum.Expense
        },
        new CategoryEntity()
        {
            Name = "Зарплата",
            IconCode = "59392",
            IconColor = "4278237396",
            BlockLocation = 1,
            PositionLocation = 1,
            MoneyFlowType = MoneyFlowTypeEnum.Income
        },
        new CategoryEntity()
        {
            Name = "Вклады",
            IconCode = "59397",
            IconColor = "4289415100",
            BlockLocation = 1,
            PositionLocation = 2,
            MoneyFlowType = MoneyFlowTypeEnum.Income
        },
        new CategoryEntity()
        {
            Name = "Инвестиции",
            IconCode = "61682",
            IconColor = "4278241363",
            BlockLocation = 1,
            PositionLocation = 3,
            MoneyFlowType = MoneyFlowTypeEnum.Income
        },
        new CategoryEntity()
        {
            Name = "Стипендия",
            IconCode = "62809",
            IconColor = "4282434815",
            BlockLocation = 1,
            PositionLocation = 4,
            MoneyFlowType = MoneyFlowTypeEnum.Income
        },
        new CategoryEntity()
        {
            Name = "Долги",
            IconCode = "62805",
            IconColor = "4289653248",
            BlockLocation = 2,
            PositionLocation = 1,
            MoneyFlowType = MoneyFlowTypeEnum.Income
        },
        new CategoryEntity()
        {
            Name = "Пособия",
            IconCode = "61870",
            IconColor = "4278228616",
            BlockLocation = 3,
            PositionLocation = 1,
            MoneyFlowType = MoneyFlowTypeEnum.Income
        },
    };
}