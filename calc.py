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

#Chamber
def fnk_l_c(d_t):
	return ((math.exp(0.029*(math.log(d_t*100)**2) +0.47*math.log(d_t*100) +1.94))/100)

def fnk_v_c(l_c,d_c,d_t,theta):
	return ((math.pi/24)*(6*l_c*(d_c**2)+(((d_c**3)-(d_t**3))/(math.tan(theta)))))

def fnk_d_c(d_t,theta,v_c,l_c):
	d_c = 1.2*d_t
	i = 0
	while i < 50:
		d_c = math.sqrt(((d_t**3) + (24/math.pi) * tan(theta)  * v_c) / (d_c + 6 * tan(theta)  * l_c))
		i += 1
	return d_c

def fnk_t_w(p_c,d_c):
	return


#Input
global f,isp,r,t_c,p_c,gamma,m
f = float(input("Thrust [N] ? "))
isp = float(input("Isp [s] ? "))
r = float(input("O/F ratio ? "))
t_c = float(input("Temperature Chamber [K] ? "))
p_c = float(input("Pressure Chamber [Pa] ? "))
gamma = float(input("Specific heat ratio ? "))
m = float(input("Molar mass [g/mol] ? "))
theta = float(input("Convergent cone half-angle [°]"))
#l_s = float(input("Chamber Characteristic Length L* [m]"))

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
l_c = fnk_l_c(d_t)
v_c = fnk_v_c(l_c,d_c,d_t,theta)
d_c = fnk_d_c(d_t,theta,v_c,l_c)

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
print("")
print("Length Chamber: " +str(l_c) +" [m]")
print("Volume Chamber: " +str(v_c) +" [m^3]")
print("Diameter Chamber: " +str(d_c) +" [m]")
