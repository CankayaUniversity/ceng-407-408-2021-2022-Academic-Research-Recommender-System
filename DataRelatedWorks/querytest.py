from itertools import count
import psycopg2
import requests
import json
import schedule
import time
import playsound as ps



# try:
connection = psycopg2.connect(user="postgres",
                            password="mysecretpassword",
                            host="127.0.0.1",
                            port="5432",
                            database="postgres")

                            
cursor = connection.cursor()









#countFlag=1 #for def task


# def areas_tasks():
#     #testrun
#     postgreSQL_select_Query = "select area_id from area2 where area_id = 'time-series' "
#     cursor.execute(postgreSQL_select_Query)
#     area_Ids = cursor.fetchall()
    
    
#     while area_Ids is not None:
        
#         for row in area_Ids:

            
#             print(row[0])
            

#             #used previously
#             #link = "https://paperswithcode.com/api/v1/areas/{}/tasks/".format(row[0])

#             #link = "https://paperswithcode.com/api/v1/areas/audio/tasks/"

#             #page&paperlı olan 
#             link = "https://paperswithcode.com/api/v1/areas/{}/tasks/?page=1&items_per_page=500".format(row[0])

            
            
#             response = requests.get(link)
#             print(response.status_code)
#             print(area_Ids)
            


#             #print(response.content)
#             jsonResponse = response.json()

            
#             #print(jsonResponse.results)
#             #print(response)
#             #kontrol et tekrarliyor mu ayni veriyi
#             #IF NOT EXISTS ( SELECT 1 FROM Users WHERE FirstName = 'John' AND LastName = 'Smith' )
#             #BEGIN
#             #    INSERT INTO Users (FirstName, LastName) VALUES ('John', 'Smith')
#             #END

#             #insert kismi(original)
#             #postgres_insert_query = """ INSERT INTO mobile (ID, MODEL, PRICE) VALUES (%s,%s,%s)"""
#             #record_to_insert = (5, 'One Plus 6', 950)
#             #cursor.execute(postgres_insert_query, record_to_insert)
#             #benim kullanacagim kisim
#             #postgres_insert_query = """ INSERT INTO task2 (task_id, task_name, description, area_type) VALUES (%s,%s,%s,%s)"""
#             #record_to_insert = (jsonResponse['results'][x]['id'], jsonResponse['results'][x]['name'], jsonResponse['results'][x]['description'], area_Ids)
#             #cursor.execute(postgres_insert_query, record_to_insert)

            
#             #for x in range(jsonResponse['count']):
        
#             for x in range(jsonResponse['count']):
#                 if(jsonResponse['results'][x]['id']!='image-to-image-translation' and jsonResponse['results'][x]['id']!='code-search'and jsonResponse['results'][x]['id']!='audio-visual-synchronization'and jsonResponse['results'][x]['id']!='3d-hand-pose-estimation'and jsonResponse['results'][x]['id']!='link-prediction' and jsonResponse['results'][x]['id']!='knowledge-base-completion' and jsonResponse['results'][x]['id']!='3d-face-reconstruction' and jsonResponse['results'][x]['id']!='medical-image-retrieval' and jsonResponse['results'][x]['id']!='breast-cancer-detection' and jsonResponse['results'][x]['id']!='generalized-zero-shot-learning' and jsonResponse['results'][x]['id']!='knowledge-graph-embeddings' and jsonResponse['results'][x]['id']!='abnormal-event-detection-in-video' and jsonResponse['results'][x]['id']!='graph-embedding' and jsonResponse['results'][x]['id']!='metric-learning' and jsonResponse['results'][x]['id']!='multi-label-classification' and jsonResponse['results'][x]['id']!='few-shot-image-classification' and jsonResponse['results'][x]['id']!='anomaly-detection-in-surveillance-videos' and jsonResponse['results'][x]['id']!='ensemble-learning' and jsonResponse['results'][x]['id']!='knowledge-graph-embedding'  and jsonResponse['results'][x]['id']!='few-shot-camera-adaptive-color-constancy'  and jsonResponse['results'][x]['id']!='gpr'and jsonResponse['results'][x]['id']!='neural-network-compression'and jsonResponse['results'][x]['id']!='deception-detection-in-videos'and jsonResponse['results'][x]['id']!='lake-ice-detection'and jsonResponse['results'][x]['id']!='continual-learning' and jsonResponse['results'][x]['id']!='trajectory-prediction' and jsonResponse['results'][x]['id']!='imputation'  and jsonResponse['results'][x]['id']!='learning-to-rank'  and jsonResponse['results'][x]['id']!='synthetic-data-generation' and jsonResponse['results'][x]['id']!='hypothesis-testing'  and jsonResponse['results'][x]['id']!='non-intrusive-load-monitoring'and jsonResponse['results'][x]['id']!='fairness'and jsonResponse['results'][x]['id']!='music-generation'and jsonResponse['results'][x]['id']!='audio-super-resolution'and jsonResponse['results'][x]['id']!='deep-attention'and jsonResponse['results'][x]['id']!='automatic-post-editing'and jsonResponse['results'][x]['id']!='chatbot'and jsonResponse['results'][x]['id']!='learning-with-noisy-labels'and jsonResponse['results'][x]['id']!='visual-dialogue'and jsonResponse['results'][x]['id']!='language-identification'and jsonResponse['results'][x]['id']!='handwritten-chinese-text-recognition'and jsonResponse['results'][x]['id']!='sentence-embeddings-for-biomedical-texts'and jsonResponse['results'][x]['id']!='active-learning'and jsonResponse['results'][x]['id']!='sentence-embeddings'and jsonResponse['results'][x]['id']!='multi-label-text-classification'and jsonResponse['results'][x]['id']!='few-shot-relation-classification'and jsonResponse['results'][x]['id']!='gender-bias-detection'and jsonResponse['results'][x]['id']!='emotion-classification'and jsonResponse['results'][x]['id']!='offline-handwritten-chinese-character'and jsonResponse['results'][x]['id']!='paraphrase-generation'and jsonResponse['results'][x]['id']!='entity-alignment'and jsonResponse['results'][x]['id']!='sentence-embedding'and jsonResponse['results'][x]['id']!='dqn-replay-dataset'and jsonResponse['results'][x]['id']!='object-tracking'and jsonResponse['results'][x]['id']!='music-generation'and jsonResponse['results'][x]['id']!='object-tracking'and jsonResponse['results'][x]['id']!='program-repair'and jsonResponse['results'][x]['id']!='visual-reasoning'and jsonResponse['results'][x]['id']!='abstract-argumentation'and jsonResponse['results'][x]['id']!='commonsense-rl'and jsonResponse['results'][x]['id']!='3d-character-animation-from-a-single-photo'and jsonResponse['results'][x]['id']!='spoken-language-understanding'and jsonResponse['results'][x]['id']!='dialogue-generation'and jsonResponse['results'][x]['id']!='talking-face-generation' and jsonResponse['results'][x]['id']!='acoustic-echo-cancellation' and jsonResponse['results'][x]['id']!='voice-conversion' and jsonResponse['results'][x]['id']!='social-media-popularity-prediction' and jsonResponse['results'][x]['id']!='eeg-decoding' and jsonResponse['results'][x]['id']!='math-word-problem-solving' and jsonResponse['results'][x]['id']!='eeg' and jsonResponse['results'][x]['id']!='video-quality-assessment'):
#                     postgres_insert_query = """ INSERT INTO task2 (task_id, task_name, description, area_type) VALUES (%s,%s,%s,%s)"""
#                     record_to_insert = (jsonResponse['results'][x]['id'], jsonResponse['results'][x]['name'], jsonResponse['results'][x]['description'], row)
#                     cursor.execute(postgres_insert_query, record_to_insert)

#                     print(x)
#                     print(jsonResponse['results'][x]['id']) #oldu bunu uygula
#                     #print(jsonResponse['results'][x]['name'])
#                     #print(jsonResponse['results'][x]['description']+"\n")

#                     connection.commit()
#                     count = cursor.rowcount
#                     print(count, "Record inserted successfully into task2 table")
#                 #print(jsonResponse["results.id"])
#                 #print(jsonResponse[results[0].id])
#                 #rint(response[])
#                 #print(jsonResponse["count"])
#                 #print(jsonResponse["results"])
#                 #print(jsonResponse["id"])
#                 #print(jsonResponse["name"])
#                 #print(jsonResponse["description"])
                

#                 #print(response.text)
#                 #print(eid)
#             area_Ids = cursor.fetchone()


    #paper/tasks link
    #https://paperswithcode.com/api/v1/papers/007-democratically-finding-the-cause-of/tasks/

    #HERE FOR REFERENCE
    #links=[]
    #for i in range (1791,1792): #1771 
    #links.append("https://paperswithcode.com/api/v1/papers/?page={}&items_per_page=500".format(i))

    #identifying papers that dont fullfill the minimum requirements
    #postgreSQL_select_Query = "delete * from papers where (abstract = '' OR pdf_url = '' OR github_url = '' OR title = '') limit 10"
    #cursor.execute(postgreSQL_select_Query)
    #eid = cursor.fetchone()
    #
    #while eid is not None:
    #   print(eid)
    #   eid = cursor.fetchone()



# def waitFor429():
#     print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#     print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#     print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#     print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#     print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#     time.sleep(600)
#     print("10 minutes up less than 10 minutes remaining 10 minutes up less than 10 minutes remaining 10 minutes up less than 10 minutes remaining 10 minutes up less than 10 minutes remaining 10 minutes up less than 10 minutes remaining")
#     time.sleep(300)
#     print("5 min remaining")
#     print("5 min remaining")
#     print("5 min remaining")
#     print("5 min remaining")
#     time.sleep(300)




#str to array example
# # input comma separated elements as string 
# str = "mito,ilo,cuc"

# # conver to the list
# list = str.split (",")
# print ("list: ", list)

def add_task_quantity():
    print("start")
    cnt=1
    postgreSQL_select_Query = "select task_id from task2 where done_quantity=false limit 500"
    cursor.execute(postgreSQL_select_Query)
    paper_tasks = cursor.fetchall()
    print(paper_tasks)
    for row in paper_tasks:
        print("\n","!!!",cnt,"!!!")
        #print(row)
        print(row[0])
        postgreSQL_select_Query_Count = """ select count(*) from papers_tasks where task='{}' """.format(row[0])
        cursor.execute(postgreSQL_select_Query_Count)
        task_Count = cursor.fetchone()
        print(task_Count[0])
        

        postgres_insert_query = """ UPDATE task2 SET quantity={} WHERE task_id='{}'""".format(task_Count[0],row[0])
        cursor.execute(postgres_insert_query)
        connection.commit()
        print("quantity set")

        postgres_insert_query = """ UPDATE task2 SET done_quantity=true WHERE task_id='{}'""".format(row[0])
        cursor.execute(postgres_insert_query)
        connection.commit()
        print("done_quantity set")

        cnt=cnt+1





def strToArray():
    cnt=1
    postgreSQL_select_Query = "select id,task_types from papers5 where done_tasks_str=false limit 12"
    cursor.execute(postgreSQL_select_Query)
    paper_tasks = cursor.fetchall()
    print(paper_tasks)
    for row in paper_tasks:
        print("!!!",cnt,"!!!")
        #print(row)
        print(row[0])
        print(row[1])
        arr_len=len(paper_tasks)
        #print(arr_len)
        list = row[1].split(",")
        print("list: ",list)
        list_len=len(list)
        print(list_len)
        print("\n")

        postgres_insert_query = """ UPDATE papers5 SET done_tasks_str=true WHERE id='{}'""".format(row[0])
        #print(postgres_insert_query)
        cursor.execute(postgres_insert_query)
        connection.commit()

        for x in list:
            

            # INSERT INTO papers_tasks(id,task) 
            # VALUES('test_id','test_task');
            
            postgres_insert_query = """ INSERT INTO papers_tasks (id, task) VALUES (%s,%s)"""
            record_to_insert = (row[0],x)
            cursor.execute(postgres_insert_query, record_to_insert)
            connection.commit()
            print("id: "+row[0]+" task: "+x)
            
            
        cnt=cnt+1


            # postgres_insert_query = """ INSERT INTO task2 (task_id, task_name, description, area_type) VALUES (%s,%s,%s,%s)"""
            # record_to_insert = (jsonResponse['results'][x]['id'], jsonResponse['results'][x]['name'], jsonResponse['results'][x]['description'], row)
            # cursor.execute(postgres_insert_query, record_to_insert)

            # print(x)
            # print(jsonResponse['results'][x]['id']) 
            # #print(jsonResponse['results'][x]['name'])
            # #print(jsonResponse['results'][x]['description']+"\n")

            # connection.commit()
            # count = cursor.rowcount

        print("\n")
        
        
        #print(paper_tasks[0][1]+"\n")


# def papers_tasks():
#     print("hello world")
#     countFlag=1



#     #postgreSQL_select_Query = "select id from papers3 where done_task=false limit 1000"
#     #before 's'
#     #postgreSQL_select_Query = "select id from papers3 where (id LIKE 'a%' and done_task=false or id LIKE 'b%' and done_task=false  or id LIKE 'c%' and done_task=false or id LIKE 'd%' and done_task=false or id LIKE 'e%' and done_task=false or id LIKE 'f%' and done_task=false or id LIKE 'g%' and done_task=false or id LIKE 'h%' and done_task=false or id LIKE 'i%'and done_task=false or id LIKE 'j%'and done_task=false or id LIKE 'k%'and done_task=false or id LIKE 'l%'and done_task=false or id LIKE 'm%' and done_task=false or id LIKE 'n%' and done_task=false or id LIKE 'A%' and done_task=false or id LIKE 'B%' and done_task=false  or id LIKE 'C%' and done_task=false or id LIKE 'D%' and done_task=false or id LIKE 'E%' and done_task=false or id LIKE 'F%' and done_task=false or id LIKE 'G%' and done_task=false or id LIKE 'H%' and done_task=false or id LIKE 'I%'and done_task=false or id LIKE 'J%'and done_task=false or id LIKE 'K%'and done_task=false or id LIKE 'L%'and done_task=false or id LIKE 'M%' and done_task=false  or id LIKE 'N%' and done_task=false ) limit 1000" 
#     #after 's'
#     #postgreSQL_select_Query = "select id from papers3 where (id LIKE 'a%' and done_task=false or id LIKE 'b%' and done_task=false  or id LIKE 'c%' and done_task=false or id LIKE 'd%' and done_task=false or id LIKE 'e%' and done_task=false or id LIKE 'f%' and done_task=false or id LIKE 'g%' and done_task=false or id LIKE 'h%' and done_task=false or id LIKE 'i%'and done_task=false or id LIKE 'j%'and done_task=false or id LIKE 'k%'and done_task=false or id LIKE 'l%'and done_task=false or id LIKE 'm%' and done_task=false or id LIKE 'n%' and done_task=false  or id LIKE 'o%' and done_task=false or id LIKE 'p%' and done_task=false or id LIKE 's%' and done_task=false or id LIKE 'A%' and done_task=false or id LIKE 'B%' and done_task=false  or id LIKE 'C%' and done_task=false or id LIKE 'D%' and done_task=false or id LIKE 'E%' and done_task=false or id LIKE 'F%' and done_task=false or id LIKE 'G%' and done_task=false or id LIKE 'H%' and done_task=false or id LIKE 'I%'and done_task=false or id LIKE 'J%'and done_task=false or id LIKE 'K%'and done_task=false or id LIKE 'L%'and done_task=false or id LIKE 'M%' and done_task=false or id LIKE 'N%' and done_task=false or id LIKE 'O%' and done_task=false or id LIKE 'P%' and done_task=false) limit 1000"

#     #after 'u'
#     #postgreSQL_select_Query = "select id from papers3 where (id LIKE 'a%' and done_task=false or id LIKE 'b%' and done_task=false  or id LIKE 'c%' and done_task=false or id LIKE 'd%' and done_task=false or id LIKE 'e%' and done_task=false or id LIKE 'f%' and done_task=false or id LIKE 'g%' and done_task=false or id LIKE 'h%' and done_task=false or id LIKE 'i%'and done_task=false or id LIKE 'j%'and done_task=false or id LIKE 'k%'and done_task=false or id LIKE 'l%'and done_task=false or id LIKE 'm%' and done_task=false or id LIKE 'n%' and done_task=false  or id LIKE 'o%' and done_task=false or id LIKE 'p%' and done_task=false or id LIKE 's%' and done_task=false or id LIKE 'u%'and done_task=false or id LIKE 'A%' and done_task=false or id LIKE 'B%' and done_task=false  or id LIKE 'C%' and done_task=false or id LIKE 'D%' and done_task=false or id LIKE 'E%' and done_task=false or id LIKE 'F%' and done_task=false or id LIKE 'G%' and done_task=false or id LIKE 'H%' and done_task=false or id LIKE 'I%'and done_task=false or id LIKE 'J%'and done_task=false or id LIKE 'K%'and done_task=false or id LIKE 'L%'and done_task=false or id LIKE 'M%' and done_task=false or id LIKE 'N%' and done_task=false or id LIKE 'O%' and done_task=false or id LIKE 'P%' and done_task=false) limit 1000"

#     #final
#     #postgreSQL_select_Query = "select id from papers3 where (id not LIKE 'st%' and done_task=false ) limit 1000"

#     postgreSQL_select_Query = "select id from papers3 where done_task=false limit 100"

#     cursor.execute(postgreSQL_select_Query)
#     paper_ids = cursor.fetchall()
    
#     #sql done_task test
#     #testId="a-gridded-establishment-dataset-as-a-proxy"
#     #postgres_insert_query = """ UPDATE papers3 SET done_task=true WHERE id='{}'""".format(testId)
#     #print(postgres_insert_query)
#     #cursor.execute(postgres_insert_query)
#     #connection.commit()


#     #sql task_types test
#     #testId="a-gridded-establishment-dataset-as-a-proxy"
#     #test_tasks_str="TEST_ACTUALLY_NULL"
#     #postgres_insert_query = """ UPDATE papers3 SET task_types='{}' WHERE id='{}'""".format(test_tasks_str,testId) #works 1
#     #postgres_insert_query = """ UPDATE papers3 SET task_types=NULL WHERE id='{}'""".format(testId) #works, reverse test 2
#     #cursor.execute(postgres_insert_query)
#     #connection.commit()

#     for row in paper_ids:
        
#         tasks_str=""
#         print(row[0])
#         link = "https://paperswithcode.com/api/v1/papers/{}/tasks/?page=1&items_per_page=100".format(row[0])

#         response = requests.get(link)
#         # if(response.status_code==404):
#         #     return
#         # elif(response.status_code==429):
#         #     waitFor429()
#         #     return

#         if(response.status_code==429):
#             ps.playsound("C:\\Users\\Anıl Mithatcan Akbaş\\Desktop\\st.mp3")
#             waitFor429()
            
#             print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#             print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#             print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#             print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#             print("Wait for 429Wait for 429Wait for 429Wait for 429Wait for 429")
#             time.sleep(15)  
#             return


#         print(response.status_code)
#         if(response.status_code==404):
#             print("404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 404 ")
#             postgres_insert_query = """ UPDATE papers3 SET rsponse_fourzrofour=true WHERE id='{}'""".format(row[0])     
#             cursor.execute(postgres_insert_query)
#             connection.commit()

#             postgres_insert_query = """ UPDATE papers3 SET done_task=true WHERE id='{}'""".format(row[0]) 
#             cursor.execute(postgres_insert_query)
#             connection.commit()
#             countFlag=countFlag+1
        
#         jsonResponse = response.json()
        
#         if(response.status_code!=404):


#             #print(jsonResponse['count'])
#             if (jsonResponse['count']==0):
#                 print("{}'s count is ZERO".format(row[0]))
#                 postgres_insert_query = """ UPDATE papers3 SET done_task=true WHERE id='{}'""".format(row[0])
                
#                 cursor.execute(postgres_insert_query)
#                 connection.commit()
#                 countFlag=countFlag+1

#             else:                
#                 for x in range(jsonResponse['count']):
#                     print(jsonResponse['results'][x]['id']) #oldu bunu uygula
#                     if(x==0):
#                         tasks_str=tasks_str+jsonResponse['results'][x]['id']
#                     else:
#                         tasks_str=tasks_str+","+jsonResponse['results'][x]['id']
#                     #print(jsonResponse['results'][x]['name'])
#                     #print(jsonResponse['results'][x]['description'])

#                     print("\n")
#                     print(tasks_str)

                
#                 postgres_insert_query = """ UPDATE papers3 SET task_types='{}' WHERE id='{}'""".format(tasks_str,row[0]) #works 1
#                 cursor.execute(postgres_insert_query)
#                 connection.commit()

#                 postgres_insert_query = """ UPDATE papers3 SET done_task=true WHERE id='{}'""".format(row[0])
#                 cursor.execute(postgres_insert_query)
#                 connection.commit()
#                 countFlag=countFlag+1
#             #print("count:%s",countFlag)
#         print("count:%s",countFlag)      
#         #paper_ids = cursor.fetchone()
        




#areas_tasks()


# main_count=1
# while 1:
    
#     papers_tasks()
#     main_count+=1
#     if(main_count%50==0):
#         print("\n!!429Timeout!!!",main_count,"!!!!600SECONDS!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!429Timeout!!!!!!",main_count,"!!!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!429Timeout!!!!!!",main_count,"!!!!600SECONDS!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!429Timeout!!!!!!",main_count,"!!!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!429Timeout!!!!!!",main_count,"!!600SECONDS!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!") 
#         time.sleep(600)
#     else:
#         print("\n!!!!!!!!",main_count,"!!!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!!!!!!!",main_count,"!!!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!!!!!!!",main_count,"!!!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!!!!!!!",main_count,"!!!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         print("\n!!!!!!!!",main_count,"!!!!!!!!!",main_count,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#         time.sleep(1) 
#   
#flag=1         
#while 1:
       
#    strToArray()
#    print("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",flag,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#    time.sleep(15)
#    flag=flag+1

#flag=1         
#while 1:
       
#    add_task_quantity()
#    print("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!",flag,"!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!")
#    time.sleep(15)
#    flag=flag+1

add_task_quantity()

# except (Exception, psycopg2.DatabaseError) as error:
#         print(error)
# finally:
#     if connection is not None:
#         #connection.close()
#         print(countFlag) 
#         print("postgres connection is closed \n")