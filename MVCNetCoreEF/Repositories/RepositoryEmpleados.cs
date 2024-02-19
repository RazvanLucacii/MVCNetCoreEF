using MVCNetCoreEF.Data;
using MVCNetCoreEF.Models;

namespace MVCNetCoreEF.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;
        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }

        public List<string> GetOficios()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        public List<Empleado> GetEmpleadosOficio(string oficio)
        {
            var consulta = from datos in this.context.Empleados
                         where datos.Oficio == oficio
                         select datos;
            return consulta.ToList();
        }

        public ModelEmpleados IncrementarSalarioOficios(int incremento, string oficio)
        {
            List<Empleado> empleados = this.GetEmpleadosOficio(oficio);
            foreach (Empleado empleado in empleados)
            {
                empleado.Salario += incremento;
            }
            this.context.SaveChanges();
            int suma = empleados.Sum(x => x.Salario);
            double media = empleados.Average(z => z.Salario);
            ModelEmpleados model = new ModelEmpleados();
            model.Empleados = empleados;
            model.SumaSalarial = suma;
            model.MediaSalarial = media;
            return model;
        }
    }
}
