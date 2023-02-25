package org.itstep.service;

import org.itstep.annotation.Cached;
import org.itstep.aspect.CachedAspect;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

@Service
public class FibonachyCalculatorImpl implements FibonachyCalculator {

    @Autowired
    private FibonachyCalculator fc;
    @Cached
    @Override
    public int calculate(int num){
        return num <= 1 ? num : fc.calculate(num-1) + fc.calculate(num-2);
    }
}
