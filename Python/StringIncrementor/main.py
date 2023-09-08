import re

def increment_string(strng: str) -> str:
    print(strng)
    regex_result = re.match(r'(.*?)(\d+)$', strng)
    if not regex_result:
        return strng + '1'
    regex_groups = regex_result.groups()
    number_part = int('1' + regex_groups[1]) + 1
    print(regex_groups[0] + str(number_part)[1:])
    return regex_groups[0] + str(number_part)[1:]

increment_string('fo99obar99')
increment_string('foobar099')
increment_string('hello123')
increment_string('hello00123')
increment_string('123')
increment_string('test')
increment_string('hg9898asdasd023')