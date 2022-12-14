using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HWOOP7.data
{
    internal class Car
    {
        private string _id;
        private string _model;
        private string _color;
        private string _namber;

        private Car(string id, string model, string color, string namber)
        {
            _id = id;
            _model = model;
            _color = color;
            _namber = namber;
        }

        private Car(string model, string color, string namber)
        {
            _id = Guid.NewGuid().ToString("N");
            _model = model;
            _color = color;
            _namber = namber;
        }

        public static Car Create(string model, string color, string namber)
        {
            return new Car(model, color, namber);
        }

        public static Car Load(string id, string model, string color, string namber)
        {
            return new Car(id, model, color, namber);
        }

        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string? ToString()
        {
            return $"id:{this.Id} model:{this.Model} color:{this.Color} number:{this.Namber}";
        }

        public string Id { get { return _id; } }
        public string Model { get { return _model; } set { this._model = value; } }  

        public string Color { get { return _color; } set { this._color = value; } }
        public string Namber { get { return _namber; } set { this._namber = value; } }



    }
}
