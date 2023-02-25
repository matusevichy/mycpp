package org.itstep.aspect;

import org.aspectj.lang.ProceedingJoinPoint;
import org.aspectj.lang.annotation.Around;
import org.aspectj.lang.annotation.Aspect;
import org.springframework.stereotype.Component;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

@Component
@Aspect
public class CachedAspect {

    private Map<String, Integer> cache;

    public CachedAspect() {
        if (this.cache == null) this.cache = new HashMap<>();
    }

    @Around("@annotation(org.itstep.annotation.Cached)")
    Object calculate(ProceedingJoinPoint jp) throws Throwable {
        var className = jp.getSignature().getDeclaringTypeName();
        var methodName = jp.getSignature().getName();
        var key = className+"."+methodName+"."+jp.getArgs()[0].toString();
        System.out.println(key);
        Object object;
        if(cache.containsKey(key)) object = cache.get(key);
        else
        {
            object = jp.proceed();
            cache.put(key, (Integer) object);
            System.out.println(object);
        }
        return object;
    }
}
