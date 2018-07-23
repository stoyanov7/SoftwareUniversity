abstract class Melon {
    weight: number
    melonSort: string
    name: string

    constructor(weight, melonSort) {
        this.weight = weight
        this.melonSort = melonSort
        this.name = this.constructor.name
    }

    toString(): string {
        let element: string = this.name
        .split('melon')
        .filter((e) => e !== '')[0]

        if (this.name === 'Melolemonmelon') {
            element = 'Water'
        }

        return `Element: ${element}\nSort: ${this.melonSort}\n`
    }  
}

class Watermelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort)
    }

    elementIndex(): number {
        return this.weight * this.melonSort.length
    }

    toString(): string {
        return super.toString() + `Element Index: ${this.elementIndex()}`
    }
}

class Firemelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort)
    }

    elementIndex(): number {
        return this.weight * this.melonSort.length
    }

    toString(): string {
        return super.toString() + `Element Index: ${this.elementIndex()}`
    }
}

class Earthmelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort)
    }

    elementIndex(): number {
        return this.weight * this.melonSort.length
    }

    toString(): string {
        return super.toString() + `Element Index: ${this.elementIndex()}`
    }
}

class Airmelon extends Melon {
    constructor(weight, melonSort) {
        super(weight, melonSort)
    }

    elementIndex(): number {
        return this.weight * this.melonSort.length
    }

    toString(): string {
        return super.toString() + `Element Index: ${this.elementIndex()}`
    }
}

class Melolemonmelon extends Watermelon {
    counter: number
    elements: any
    
    constructor(weight, melonSort) {
        super(weight, melonSort)
        this.counter = 0
        this.elements = [Watermelon, Firemelon, Earthmelon, Airmelon]
    }

    morph(): void {
        this.counter++
    }

    toString(): string {
        return new this.elements[this.counter % 4](this.weight, this.melonSort).toString()
    }
}