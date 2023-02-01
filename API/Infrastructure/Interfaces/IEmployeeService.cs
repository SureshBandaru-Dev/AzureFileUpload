public interface IEmployeeService  
    {  

        Task<IList<Employee>> GetEmployeeRecordsAsync(); 
        Task<string> AddEmployeeRecordAsync(Employee model);       
        Task<Employee?> GetEmployeeSingleRecordAsync(string id);              
        Task<bool> UpdateEmployeeRecordAsync(Employee model);
        Task<bool> DeleteEmployeeRecordAsync(Employee model);
    }