import { HTMLSelect } from "@blueprintjs/core";
import * as React from "react";
import { retrieveBranches } from "src/api/dataCommunication";
import { Branch } from "src/api/Models";
import { isUndefinedOrNull } from "src/utils/utilities";

interface Props {
    selectedBranch: Branch,
    onBranchSelect: (newBranch: Branch) => void
}

interface State {
    branches: Branch[];
}

const createInitialState = () : State => ({
    branches: []
})

export default class BranchSelector extends React.Component<Props, State>{

    public state = createInitialState();

    async componentDidMount() {
        const branches = await retrieveBranches();
        this.setState({
            branches: branches
        }) 
        
        if(branches.length > 0){
            this.props.onBranchSelect(branches[0]);
        }
    }

    render(){
        let branches: string[];
        if(this.state.branches.length === 0)
        {
            branches = [ "no branches found"]
        }else{
            branches = this.state.branches.map(branch => branch.name);
        }

        return(
            <div className="branch-selector">
                <span>Select branch: </span>
                <HTMLSelect
                    options={branches}
                    value={this.getSelectedOptionString()}
                    onChange={this.onChange}
                />
            </div>
        )
    }
    
    private getSelectedOptionString = () => {
        if(isUndefinedOrNull(this.props.selectedBranch)){
            return "no branch selected";
        }else{
            return this.convertBranchToOptionString(this.props.selectedBranch);
        }
    }

    private onChange = (event: React.ChangeEvent<HTMLSelectElement>) => {
        const optionString = event.target.value;
        const branch = this.convertOptionStringToBranch(optionString);
        this.props.onBranchSelect(branch);
    }

    private convertBranchToOptionString = (branch : Branch) => branch.name;

    private convertOptionStringToBranch = (str: string) => {
        const branch = this.state.branches.find(branch => branch.name === str);
        return isUndefinedOrNull(branch) ? null : branch;

    }
}