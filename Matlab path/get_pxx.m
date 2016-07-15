function ans = get_pxx(P,rob,step)

p11 = P(rob,step,1,1)
p12 = P(rob,step,1,2)
p13 = P(rob,step,1,3)
p22 = P(rob,step,2,2)
p23 = P(rob,step,2,3)
p33 = P(rob,step,3,3)

ans = [p11,p12,p13,p22,p23,p33];