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
                var dummy = from eval in asigConEval.Value
                    group eval by eval.Alumno.UniqueID
                    into grupoEvalAlumno
                    select new
                    {
                        AlumnoID = grupoEvalAlumno.Key,
                        Promedio = grupoEvalAlumno.Average( evaluacion => evaluacion.Nota)
                    };
            }
            return rta;
        }
    }
}