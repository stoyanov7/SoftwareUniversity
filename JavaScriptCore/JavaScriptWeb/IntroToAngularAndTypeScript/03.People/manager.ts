namespace People {
    class Manager extends Employee {
        dividend: number

        constructor(name: string, age: number) {
            super(name, age)
            this.dividend = 0
            this.tasks.push(' scheduled a meeting.')
            this.tasks.push(' is preparing a quarterly meeting.')
        }

        getSalary(): number {
            return this.salary + this.dividend
        }
    }
}