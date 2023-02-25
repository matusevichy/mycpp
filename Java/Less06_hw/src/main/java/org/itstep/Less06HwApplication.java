package org.itstep;

import org.itstep.service.FibonachyCalculator;
import org.itstep.service.FibonachyCalculatorImpl;
import org.springframework.boot.CommandLineRunner;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.context.annotation.Bean;

@SpringBootApplication
public class Less06HwApplication {

    final FibonachyCalculator fibonachyCalculator;

    public Less06HwApplication(FibonachyCalculator fibonachyCalculator){
        this.fibonachyCalculator = fibonachyCalculator;
    }
    public static void main(String[] args) {
        SpringApplication.run(Less06HwApplication.class, args);
    }

    @Bean
    public CommandLineRunner getRunner(){
        return (args) -> {
            System.out.println(fibonachyCalculator.calculate(6));
            System.out.println(fibonachyCalculator.calculate(7));
            System.out.println(fibonachyCalculator.calculate(8));
        };
    }

}
