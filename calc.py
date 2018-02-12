import math

#Globals
global g,R,Patm
g = 9.81
R = 8.3145
Patm = 101352.9

#Mass Flow
def fnk_w(f,isp):
	return ((f/g)/isp)

def fnk_w_f(w,r):
	return (w/(r+1))

def fnk_w_o(w,w_f):
	return (w-w_f)


#Throat
def fnk_t_t(t_c,gamma):
	return (t_c*(1/(1+((gamma-1)/2))))

def fnk_p_t(p_c,gamma):
	return (p_c*math.pow((1+((gamma-1)/2)),-(gamma/(gamma-1))))

def fnk_a_t(w,p_t,t_t,m,gamma):
	return ((w/p_t)*math.sqrt((R*t_t)/(m*0.001*gamma)))

def fnk_d_t(a_t):
	return math.sqrt(((4*a_t)/math.pi))


#Exit
def fnk_m_e(p_c,gamma):
	return (math.sqrt((2/(gamma-1))*(math.pow((p_c/Patm),((gamma-1)/gamma))-1)))

def fnk_a_e(m_e,a_t,gamma):
	return ((a_t/m_e)*math.pow((1+((gamma-1)/2)*math.pow(m_e,2))/((gamma+1)/2),(gamma+1)/(2*(gamma-1))))

def fnk_d_e(a_e):
	return math.sqrt(((4*a_e)/math.pi))

	
#Input
global f,isp,r,t_c,p_c,gamma,m
f = float(input("Thrust [N] ? "))
isp = float(input("Isp [s] ? "))
r = float(input("O/F ratio ? "))
t_c = float(input("Temperature Chamber [K] ? "))
p_c = float(input("Pressure Chamber [Pa] ? "))
gamma = float(input("Specific heat ratio ? "))
m = float(input("Molar mass [g/mol] ? "))

#Calc
global w,w_f,w_o,t_t,p_t,a_t,d_t,m_e,a_e,d_e
w = fnk_w(f,isp)
w_f = fnk_w_f(w,r)
w_o = fnk_w_o(w,w_f)
t_t = fnk_t_t(t_c,gamma)
p_t = fnk_p_t(p_c,gamma)
a_t = fnk_a_t(w,p_t,t_t,m,gamma)
d_t = fnk_d_t(a_t)
m_e = fnk_m_e(p_c,gamma)
a_e = fnk_a_e(m_e,a_t,gamma)
d_e = fnk_d_e(a_e)

#Print
print("")
print("Mass flow: " +str(w) +" [kg/s]")
print("Mass flow F: " +str(w_f) +" [kg/s]")
print("Mass flow O: " +str(w_o) +" [kg/s]")
print("")
print("Temperature Throat: " +str(t_t) +" [K]")
print("Pressure Throat: " +str(p_t) +" [Pa]")
print("Area Throat: " +str(a_t) +" [m^2]")
print("Diameter Throat: " +str(d_t) +" [m]")
print("")
print("Speed Exit: " +str(m_e) +" [Mach]")
print("Area Exit: " +str(a_e) +" [m^2]")
print("Diameter Exit: " +str(a_e) +" [m]")