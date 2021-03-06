﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Inedo.Documentation;
using Inedo.ExecutionEngine;
using Inedo.Extensibility;
using Inedo.Extensibility.VariableFunctions;

namespace Inedo.Extensions.VariableFunctions.Lists
{
    [ScriptAlias("ListInsert")]
    [Description("Inserts an item into a list.")]
    [Tag("lists")]
    public sealed class ListInsertVariableFunction : VectorVariableFunction
    {
        [VariableFunctionParameter(0)]
        [DisplayName("list")]
        [Description("The list.")]
        public IEnumerable<RuntimeValue> List { get; set; }

        [VariableFunctionParameter(1)]
        [DisplayName("item")]
        [Description("The item.")]
        public RuntimeValue Item { get; set; }

        [VariableFunctionParameter(2, Optional = true)]
        [DisplayName("index")]
        [Description("The index. 0 inserts the item at the start of the list. If this parameter is not present, the item is added to the end of the list.")]
        public int? Index { get; set; }

        protected override IEnumerable EvaluateVector(IVariableFunctionContext context)
        {
            var list = this.List.ToList();
            if (this.Index.HasValue)
            {
                list.Insert(this.Index.Value, this.Item);
            }
            else
            {
                list.Add(this.Item);
            }
            return list;
        }
    }
}
