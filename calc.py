#Globals
global g = 9.81;
global R = 8.3145;
global Patm = 101352.9;
#Flussraten
def fnk_w(f,isp)
global w = ((f/g)/isp);
	return w;

def fnk_w_f(w,r)
global w_f = (w/(r+1));
	return w_f;

def fnk_w_o(w,w_f)
global w_o = (w-w_f);
	return w_o;


#Düsenhals
def fnk_t_t(t_c,gamma)
global t_t = (t_c*(1/(1+((gamma-1)/2))));
	return t_t;

def fnk_p_t(p_c,gamma)
global p_t = (p_c*math.pow((1+((gamma-1)/2)),-(gamma/(gamma-1))));
	return p_t;

def fnk_a_t(w,p_t,t_t,m,gamma)
global a_t = ((w/p_t)*math.sqrt((R*t_t)/(m*0.001*gamma)));
	return a_t;

def fnk_d_t(a_t)
global d_t = math.sqrt(((4*a_t)/math.PI));
	return d_t;


#Exit
def fnk_m_e(p_c,gamma)
global m_e = (math.sqrt((2/(gamma-1))*(math.pow((p_c/Patm),((gamma-1)/gamma))-1)));
	return m_e;

def fnk_a_e(m_e,a_t,gamma)
global a_e = ((a_t/m_e)*math.pow((1+((gamma-1)/2)*math.pow(m_e,2))/((gamma+1)/2),(gamma+1)/(2*(gamma-1))));
	return a_e;

def fnk_d_e(a_e)
global d_e = math.sqrt(((4*a_e)/math.pi));
	return d_e;
