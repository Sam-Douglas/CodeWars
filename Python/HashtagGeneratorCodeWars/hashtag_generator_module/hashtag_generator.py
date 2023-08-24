def generate_hashtag(sentence: str) -> str | bool:
    WORD_LIMIT = 140
    if not sentence:
        return False
    hashtag =  "#" + "".join([word.capitalize() for word in sentence.split()])
    if len(hashtag) > WORD_LIMIT:
        return False
    return hashtag