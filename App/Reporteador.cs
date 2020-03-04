using System;
using System.Linq;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario,IEnumerable<ObjetoEscuelaBase>> dicObsEsc)
        {
            if (dicObsEsc == null)
                throw new ArgumentNullException(nameof(dicObsEsc));
            _diccionario = dicObsEsc;
        }
        public IEnumerable<Evaluacion> GetListaEvaluaciones()
        {
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            else
            {
                return new List<Evaluacion>();
            }
        }
        public IEnumerable<string> GetListaAsignaturas()
        {
            return GetListaAsignaturas(out var dummy);
        }
        public IEnumerable<string> GetListaAsignaturas(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluaciones();
            return (from Evaluacion ev in listaEvaluaciones
                select ev.Asignatura.Nombre).Distinct();
        }
        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvaluaXAsig()
        {
            var dicRta = new Dictionary<string, IEnumerable<Evaluacion>>();
            var listaAsig = GetListaAsignaturas(out var listaEval);
            foreach (var asig in listaAsig)
            {
                var evalsAsig = from eval in listaEval
                where eval.Asignatura.Nombre == asig
                select eval;
                dicRta.Add(asig, evalsAsig);
            }
            
            return dicRta;
        }
        public Dictionary<string, IEnumerable<Object>> GetPromAlumPorAsignatura()
        {
            var rta = new Dictionary<string, IEnumerable<Object>>();
            var dicEvalXAsig = GetDicEvaluaXAsig();
            foreach (var asigConEval in dicEvalXAsig)
            {
                var promsAlumn = from eval in asigConEval.Value
                    group eval by new
                    {
                        eval.Alumno.UniqueID,
                        eval.Alumno.Nombre
                    } 
                    into grupoEvalAlumno
                    select new AlumnoPromedio
                    {
                        alumnoID = grupoEvalAlumno.Key.UniqueID,
                        alumnoNombre = grupoEvalAlumno.Key.Nombre,
                        promedio = grupoEvalAlumno.Average( evaluacion => evaluacion.Nota)
                    };
                rta.Add(asigConEval.Key, promsAlumn);
            }
            return rta;
        }
        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetTopAluPorAsig(int max) {
			var resp = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
			var dicPromAluPorAsig = GetPromAlumPorAsignatura();
			foreach(var asig_aluProms in dicPromAluPorAsig) {
				var topProms = asig_aluProms.Value.Cast<AlumnoPromedio>().OrderByDescending(e => e.promedio).Take(max);
				resp.Add(asig_aluProms.Key, topProms);
			}
			return resp;
		}
    }
}