package com.softuni.entity;

public class Calculator {
    private double leftOperand;
    private  double rightOperand;
    private String operator;

    public Calculator(double leftOperand, double rightOperand, String operator) {
        this.leftOperand = leftOperand;
        this.rightOperand = rightOperand;
        this.operator = operator;
    }

    public double getLeftOperand() {
        return leftOperand;
    }

    public double getRightOperand() {
        return rightOperand;
    }

    public String getOperator() {
        return operator;
    }

    public double calculateResult() {
        double result;

        switch (this.getOperator()) {
            case "+":
                result = this.getLeftOperand() + this.getRightOperand();
                break;

            case "-":
                result = this.getLeftOperand() - this.getRightOperand();
                break;

            case "*":
                result = this.getLeftOperand() * this.getRightOperand();
                break;

            case "/":
                result = this.getLeftOperand() / this.getRightOperand();
                break;

            default:
                result = 0;
                break;
        }

        return result;
    }
}
