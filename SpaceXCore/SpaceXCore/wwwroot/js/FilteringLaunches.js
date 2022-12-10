dselect(document.querySelector("#select-box-launch-name"), { search: true });

function filters() {
    return {
        reusable: null,
        name: "",
        height: null,
        costPerLaunch: null,
        fetchData() {
            console.log(this.reusable);
            console.log(this.name);
            console.log(this.height);
        },
        search() {
            const searchParams = new URLSearchParams();
            const url = "/launches";

            this.reusableCheckboxEnabled && searchParams.set("reusable", this.reusable);
            this.name && searchParams.set("name", this.name);
            this.height && searchParams.set("height", this.height);
            this.costPerLaunch && searchParams.set("costPerLaunch", this.costPerLaunch);

            const queryString = searchParams.toString();
            const fullUrl = `${url}?${queryString}`;
            console.log(fullUrl);
            window.location.replace(fullUrl);
        }
    }
}