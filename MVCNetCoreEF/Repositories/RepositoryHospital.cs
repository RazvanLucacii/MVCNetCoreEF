using MVCNetCoreEF.Data;
using MVCNetCoreEF.Models;

namespace MVCNetCoreEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;
        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }

        public Hospital FindHospital(int idHospital)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital == idHospital
                           select datos;
            return consulta.FirstOrDefault();
        }

        public void InsertHospital(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = new Hospital();
            hospital.IdHospital = idHospital;
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            this.context.Hospitales.Add(hospital);
            this.context.SaveChanges();
        }

        public void ModficarHospital(int idHospital, string nombre, string direccion, string telefono, int camas)
        {
            Hospital hospital = this.FindHospital(idHospital);
            hospital.Nombre = nombre;
            hospital.Direccion = direccion;
            hospital.Telefono = telefono;
            hospital.Camas = camas;
            this.context.SaveChanges();
        }

        public void DeleteHospital(int idHospital)
        {
            Hospital hospital = this.FindHospital(idHospital);
            this.context.Hospitales.Remove(hospital);
            this.context.SaveChanges();
        }
    }
}
