using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Tournament_Management_Software.Helpers
{
    public class ObservableObject : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        private readonly Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();
        private readonly object _lock = new object();

        public bool IsValid => !HasErrors;

        protected void RaisePropertyChangedEvent(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            ValidateAsync();
        }
        protected void RaisePropertyChangedEvent(List<string> propertyNames)
        {
            foreach (var propName in propertyNames)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
                ValidateAsync();
            }
        }

        public bool HasErrors => _errors.Any(propError => propError.Value?.Count > 0);
        public void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public IEnumerable GetErrors(string propertyName)
        {
            if (propertyName != null)
            {
                List<string> errors = new List<string>();
                _errors?.TryGetValue(propertyName, out errors);
                return errors;
            }
            return null;
        }

        public Task ValidateAsync()
        {
            return Task.Run(() => ValidateProperty());
        }

        public void ValidateProperty()
        {
            lock (_lock)
            {
                var validationContext = new ValidationContext(this, null, null);
                var validationResults = new List<ValidationResult>();
                Validator.TryValidateObject(this, validationContext, validationResults, true);

                var propNames = _errors.Keys.ToList();
                _errors.Clear();
                propNames.ForEach(OnErrorsChanged);
                HandleValidationResults(validationResults);
            }
        }

        private void HandleValidationResults(IEnumerable<ValidationResult> validationResults)
        {
            var resultsByPropNames = from res in validationResults
                from name in res.MemberNames
                group res by name
                into allResults
                select allResults;

            foreach (var property in resultsByPropNames)
            {
                var messages = property.Select(res => res.ErrorMessage).ToList();
                _errors.Add(property.Key, messages);
                OnErrorsChanged(property.Key);
            }
        }
    }
}
