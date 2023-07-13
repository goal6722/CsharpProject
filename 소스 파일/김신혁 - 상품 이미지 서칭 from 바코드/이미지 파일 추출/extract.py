import os
import shutil
import json

folder_names = next(os.walk('.'))[1]

# 폴더 이름을 구분 기준으로 분리하여 리스트로 받아옴
folder_name_parts = [name.split('_') for name in folder_names]

# 결과를 저장할 폴더 경로
result_folder = './result'

# 폴더 생성
if not os.path.exists(result_folder):
    os.makedirs(result_folder)

# 로그 파일 경로
# log_file = os.path.join(result_folder, 'log.json')
log_file = 'log.json'

# 로그 파일 읽기
log_data = []
if os.path.exists(log_file):
    with open(log_file, 'r') as f:
        log_data = json.load(f)

# 출력 및 하위 폴더 내용물 확인
for i, item in enumerate(folder_name_parts):
    # print(item[0])
    print(folder_names[i])
    path = './' + folder_names[i] + '/'
    contents = os.listdir(path)
    file_names = [content for content in contents if os.path.isfile(os.path.join(path, content)) and 's' in content]
    subfolder_names = [content for content in contents if os.path.isdir(os.path.join(path, content))]
    print("Files:", end=" ")
    print(file_names)
    print("Subfolders:", end=" ")
    print(subfolder_names)
    print()

    # 파일들 중 file_names[0]에 해당하는 파일을 ./result 폴더로 이동
    for file_name in file_names:
        if file_name == file_names[0]:
            current_path = os.path.join(path, file_name)
            new_path = os.path.join(result_folder, file_name)  # ./result 폴더로 이동할 경로 설정
            shutil.move(current_path, new_path)
            # 로그에 추가
            log_data.append({"Id": item[0], "FileName": file_names[0]})

# 로그 파일 저장
with open(log_file, 'w') as f:
    json.dump(log_data, f, indent=4)

