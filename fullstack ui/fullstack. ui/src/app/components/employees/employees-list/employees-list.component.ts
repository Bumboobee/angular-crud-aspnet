import { Component, OnInit } from '@angular/core';
import employeesData from 'src/app/data/employees';
import { Employee } from 'src/app/modules/employee-list.component';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-employees-list',
  templateUrl: './employees-list.component.html',
  styleUrls: ['./employees-list.component.scss']
})
export class EmployeesListComponent implements OnInit {
  employees: Employee[] = []
  
  constructor(private employeesService: EmployeesService) {}

  ngOnInit(): void {
    this.employeesService
      .getAllEmployees()
      .subscribe({
        next: (employees) => {
          this.employees = employees
          console.log(employees)
        },
        error: (err) => {
          console.log(err)
        }
      })
  }
}
