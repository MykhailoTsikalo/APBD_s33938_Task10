export function copyText(text) {
    return navigator.clipboard.writeText(text)
        .then(() => true)
        .catch(() => false);
}

export function confirmAction(message) {
    return confirm(message);
}