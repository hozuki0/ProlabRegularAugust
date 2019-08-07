using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MVVMExample.Model
{
    public class MainModel
    {
        public ReactiveProperty<int> ID { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> HP { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Attack { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Deffence { get; set; } = new ReactiveProperty<int>();
        public ReactiveProperty<int> Speed { get; set; } = new ReactiveProperty<int>();

        public IO.SerializableStatus ToSerializableStatus()
        {
            return new IO.SerializableStatus()
            {
                ID = ID.Value,
                HP = HP.Value,
                Attack = Attack.Value,
                Deffence = Deffence.Value,
                Speed = Speed.Value,
            };
        }

        public void Save(string filePath)
        {
            System.IO.File.WriteAllText(filePath, JsonConvert.SerializeObject(ToSerializableStatus(), Formatting.Indented));
        }
    }
}
