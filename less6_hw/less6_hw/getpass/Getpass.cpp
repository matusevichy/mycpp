#include "Getpass.h"

Getpass::Getpass()
{
    this->str = nullptr;
}

char* Getpass::getPass(const char* str, ...)
{
    char** ptr = (char**) &str;
    this->str = (char*)malloc(1);
    bool first = true;
    this->str[0] = 0;
    while (*ptr)
    {
        int len = strlen(*ptr);
        this->str = (char*)realloc(this->str, strlen(this->str) + len+3);
        strcat_s(this->str, strlen(this->str)+len+1, *ptr++);
        if (first)
        {
            strcat_s(this->str, strlen(this->str) + 3, ":\\");
            first = false;
        }
        else
        {
            strcat_s(this->str, strlen(this->str) + 2, "\\");
        }
    }
    return this->str;
}

Getpass::~Getpass()
{
    free(str);
}
