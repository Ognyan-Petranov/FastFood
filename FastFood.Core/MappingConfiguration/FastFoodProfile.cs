using System;
using System.Globalization;

using AutoMapper;

using FastFood.Models;
using FastFood.Core.ViewModels.Categories;
using FastFood.Core.ViewModels.Employees;
using FastFood.Core.ViewModels.Items;
using FastFood.Core.ViewModels.Orders;
using FastFood.Core.ViewModels.Positions;

namespace FastFood.Core.MappingConfiguration
{

    public class FastFoodProfile : Profile
    {
        public FastFoodProfile()
        {
            //Positions
            this.CreateMap<CreatePositionInputModel, Position>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.PositionName));

            this.CreateMap<Position, PositionsAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(s => s.Name));

            //Category
            this.CreateMap<CreateCategoryInputModel, Category>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.CategoryName));
            this.CreateMap<Category, CategoryAllViewModel>()
                .ForMember(x => x.Name, y => y.MapFrom(x => x.Name));

            //Employees
            this.CreateMap<Position, RegisterEmployeeViewModel>()
                .ForMember(x => x.PositionId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.PositionName, y => y.MapFrom(x => x.Name));
            this.CreateMap<RegisterEmployeeInputModel, Employee>();
            //.ForMember(x => x.Name, y => y.MapFrom(x => x.Name))
            //.ForMember(x => x.Age, y => y.MapFrom(x => x.Age))
            //.ForMember(x => x.Position, y => y.MapFrom(x => x.PositionName))
            //.ForMember(x => x.PositionId, y => y.MapFrom(x => x.PositionId))
            //.ForMember(x => x.Address, y => y.MapFrom(x => x.Address));
            this.CreateMap<Employee, EmployeesAllViewModel>()
                .ForMember(x => x.Position, y => y.MapFrom(x => x.Position.Name));

            //Items
            this.CreateMap<Category, CreateItemViewModel>()
                .ForMember(x => x.CategoryId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.CategoryName, y => y.MapFrom(x => x.Name));
            this.CreateMap<CreateItemInputModel, Item>();
            this.CreateMap<Item, ItemsAllViewModels>()
                .ForMember(x => x.Category, y => y.MapFrom(x => x.Category.Name));

            //Orders
            this.CreateMap<Item, CreateOrderItemViewModel>()
                .ForMember(x => x.ItemId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.ItemName, y => y.MapFrom(x => x.Name));
            this.CreateMap<Employee, CreateOrderEmployeeViewModel>()
                .ForMember(x => x.EmployeeId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EmployeeName, y => y.MapFrom(x => x.Name));
            this.CreateMap<CreateOrderInputModel, Order>()
                .ForMember(x => x.DateTime, y => y.MapFrom(x => DateTime.UtcNow))
                .ForMember(x => x.Type, y => y.MapFrom(x => x.OrderType));
            this.CreateMap<CreateOrderInputModel, OrderItem>()
                .ForMember(x => x.ItemId, y => y.MapFrom(x => x.ItemId))
                .ForMember(x => x.Quantity, y => y.MapFrom(x => x.Quantity));
            this.CreateMap<Order, OrderAllViewModel>()
                .ForMember(x => x.Employee, y => y.MapFrom(x => x.Employee.Name))
                .ForMember(x => x.DateTime, y => y.MapFrom(x => x.DateTime.ToString("D", CultureInfo.InvariantCulture)))
                .ForMember(x => x.OrderId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.OrderType, y => y.MapFrom(x => x.Type));
        }
    }
}
