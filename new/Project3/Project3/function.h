#pragma once
#ifdef INTEGER
void Full_int(int*, int);
void Show_int(int*, int);
void Min_int(int*, int);
void Max_int(int*, int);
void Sort_int(int*, int);
void Edit_int(int*);
#define Type int
#define Full Full_int
#define Show Show_int
#define Min Min_int
#define Max Max_int
#define Sort Sort_int
#define Edit Edit_int;
#endif // INTEGER

#ifdef DOUBLE
void Full_double(double*, int);
void Show_double(double*, int);
void Min_double(double*, int);
void Max_double(double*, int);
void Sort_double(double*, int);
void Edit_double(double*);
#define Type double
#define Full Full_double
#define Show Show_double
#define Min Min_double
#define Max Max_double
#define Sort Sort_double
#define Edit Edit_double;
#endif // DOUBLE

#ifdef CHAR
void Full_char(char*, int);
void Show_char(char*, int);
void Min_char(char*, int);
void Max_char(char*, int);
void Sort_char(char*, int);
void Edit_char(char*);
#define Type char
#define Full Full_char
#define Show Show_char
#define Min Min_char
#define Max Max_char
#define Sort Sort_char
#define	Edit Edit_char;
#endif // CHAR
