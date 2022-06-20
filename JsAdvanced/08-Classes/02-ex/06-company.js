class Company {
    constructor() {
        this.departments = {};
    }

    addEmployee(name, salary, position, department) {
        this.stringValidator(name);
        this.stringValidator(position);
        this.stringValidator(department);
        this.numberValidator(salary);

        if (!this.departments.hasOwnProperty(department)) {
            this.departments[department] = {
                averageSalary: 0,
                employees: [],
            }

        }

        this.addEmployeeToDepartment(name, salary, position, department);

        this.setAverageDepartmentSalary(department);

        this.orderDepartmentsEmployees(department);

        return `New employee is hired. Name: ${name}. Position: ${position}`
    }

    bestDepartment() {

        let bestCompany = Object.entries(this.departments)[0];
        let result = `Best Department is: ${bestCompany[0]}\n`;
        result += `Average salary: ${bestCompany[1].averageSalary.toFixed(2)}\n`;
        bestCompany[1].employees.forEach(element => {
            result += `${element.name} ${element.salary} ${element.position}\n`;
        });

        return result.trimEnd('\n');


    }



    stringValidator(arg) {

        if (arg == null || arg == undefined || arg == '') {
            throw new Error('Invalid input!');
        }
    }

    numberValidator(num) {

        this.stringValidator(num)
        
        if (isNaN(num)) {
            throw new Error('Invalid input!');
        }
        if (num < 0) {
            throw new Error('Invalid input!');
        }
    }

    addEmployeeToDepartment(name, salary, position, department) {
        this.departments[department].employees.push({ name, salary, position: position });
    }

    setAverageDepartmentSalary(department) {
        let del = this.departments[department].employees.length;
        let sum = this.departments[department].employees.reduce((agg, el) => agg + el.salary, 0);
        this.departments[department].averageSalary = sum / del;
    }

    orderDepartmentsEmployees(department) {
        this.departments[department].employees.sort((f, s) => {
            let compare = s.salary - f.salary;
            if (compare == 0) {
                compare = f.name.localeCompare(s.name);
            }

            return compare;
        })
    }

}

let c = new Company();
c.addEmployee("Stanimir", 2000, "engineer", "Human resources");
c.addEmployee("Pesho", 1500, "electrical engineer", "Construction");
c.addEmployee("Slavi", 500, "dyer", "Construction");
c.addEmployee("Stan", 2000, "architect", "Construction");
c.addEmployee("Stanimir", 1200, "digital marketing manager", "Marketing");
c.addEmployee("Pesho", 1000, "graphical designer", "Marketing");
c.addEmployee("Gosho", 1350, "HR", "Human resources");
console.log(c.bestDepartment());


