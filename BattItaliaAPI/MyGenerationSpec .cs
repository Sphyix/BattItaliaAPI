using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BattItaliaAPI.DB.Client;
using BattItaliaAPI.DB.User;
using BattItaliaAPI.DB.WorkOrders;
using TypeGen.Core.SpecGeneration;

namespace BattItaliaAPI
{
    public class MyGenerationSpec : GenerationSpec 
    {
        public override void OnBeforeGeneration(OnBeforeGenerationArgs args)
        {
            AddClass<UserSelectResults>();
            AddClass<ClientSelectResults>();
            AddClass<WorkOrderLogSelect>();
            AddClass<WorkOrderSelectResults>();
            AddClass<WorkOrderProveSelect>();
            AddClass<UserWorkOrdersSelect>();

            //    AddInterface<CarDto>("output/directory");

            //    AddClass<PersonDto>()
            //        .Member(nameof(PersonDto.Id))  // specifying member options
            //        .Ignore()
            //        .Member(x => nameof(x.Age))    // you can specify member name with lambda
            //        .Type(TsType.String);

            //    AddInterface<SettingsDto>()
            //        .IgnoreBase();                 // specifying type options

            //    AddClass(typeof(GenericDto<>));    // specifying types by Type instance

            //    AddEnum<ProductType>("output/dir") // specifying an enum

            //// generate everything from an assembly

            //    foreach (Type type in GetType().Assembly.GetLoadableTypes())
            //    {
            //        AddClass(type);
            //    }

            //    // generate types by namespace

            //    IEnumerable<Type> types = GetType().Assembly.GetLoadableTypes()
            //        .Where(x => x.FullName.StartsWith("MyProject.Web.Dtos"));
            //    foreach (Type type in types)
            //    {
            //        AddClass(type);
            //    }
        }
    }
}