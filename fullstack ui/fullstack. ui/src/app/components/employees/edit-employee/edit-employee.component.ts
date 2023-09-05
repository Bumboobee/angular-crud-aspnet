import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeesService } from 'src/app/services/employees.service';
import { Employee } from 'src/app/modules/employee-list.component';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.scss']
})
export class EditEmployeeComponent {
  employeesDetails: Employee = {
    id: '',
    name: '',
    email: '',
    phone: 0,
    salary: 0,
    department: '',
  }

  constructor(private route: ActivatedRoute, private router: Router, private employeeService: EmployeesService) { }
  
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');

        if (id) {
          this.employeeService.getEmployeeById(id)
            .subscribe({
              next: (response) => {
                this.employeesDetails = response;
              }
            })
        }
      }
    });
  }

  updateEmployee() {
    this.employeeService.updateEmployee(this.employeesDetails.id, this.employeesDetails)
      .subscribe({
        next: (response) => {
          this.router.navigate(['employees'])
        }
      })
  }

  deleteEmployee(id: string) {
    this.employeeService.deleteEmployee(id)
      .subscribe({
        next: (response) => {
          this.router.navigate(['employees'])
        }
      })
  }
}
