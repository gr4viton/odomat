function ans = get_pxx_dif(P,rob1,rob2,step)

p11dif = P(rob1,step,1,1) - P(rob2,step,1,1)
p12dif = P(rob1,step,1,2) - P(rob2,step,1,2)
p13dif = P(rob1,step,1,3) - P(rob2,step,1,3)
p22dif = P(rob1,step,2,2) - P(rob2,step,2,2)
p23dif = P(rob1,step,2,3) - P(rob2,step,2,3)
p33dif = P(rob1,step,3,3) - P(rob2,step,3,3)

ans = [p11dif,p12dif,p13dif,p22dif,p23dif,p33dif];